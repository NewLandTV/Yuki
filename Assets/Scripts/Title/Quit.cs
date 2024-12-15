using System;
using UnityEngine;

public class Quit : Singleton<Quit>
{
    [SerializeField]
    private Canvas canvas;

    private Action quitEvent;

    private bool isApplicationQuit;

    private void Awake()
    {
        Initialize(this);
        Initialize();
    }

    private void Initialize()
    {
        quitEvent += () =>
        {
            canvas.enabled = true;
        };

        Application.wantsToQuit += ApplicationQuit;
    }

    public void Ask() => ApplicationQuit();

    public void Process()
    {
        isApplicationQuit = true;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Cancel()
    {
        canvas.enabled = false;
        isApplicationQuit = false;
    }

    private bool ApplicationQuit()
    {
        if (!isApplicationQuit)
        {
            quitEvent?.Invoke();
        }

        return isApplicationQuit;
    }
}
