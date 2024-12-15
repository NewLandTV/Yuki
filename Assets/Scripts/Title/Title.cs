using TMPro;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private TextMeshProUGUI versionText;

    private void Awake() => Initialize();

    private void Initialize() => versionText.text = $"v{Application.version}";

    public void StartGame()
    {
        canvas.enabled = false;

        Loading.Instance.LoadScene(Scene.Game);
    }

    public void QuitGame() => Quit.Instance.Ask();
}
