using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public enum Name
    {
        TITLE_BGM = 0
    }

    [SerializeField]
    private Name name;
    public Name IDName => name;

    [SerializeField]
    private AudioClip clip;
    public AudioClip Clip => clip;
}

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    private AudioSource bgmPlayer;

    [SerializeField]
    private Sound[] bgmDatas;

    private void Awake() => Initialize(this);

    public bool PlayBGM(Sound.Name soundName, bool loop = true)
    {
        for (int i = 0; i < bgmDatas.Length; i++)
        {
            if (bgmDatas[i].IDName == soundName)
            {
                bgmPlayer.clip = bgmDatas[i].Clip;
                bgmPlayer.loop = loop;

                bgmPlayer.Play();

                return true;
            }
        }

        return false;
    }

    public void StopBGM() => bgmPlayer.Stop();
}
