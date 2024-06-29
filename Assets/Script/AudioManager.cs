using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource seSource;
    public AudioClip[] bgmClips;
    public AudioClip[] seClips;
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }

    public void PlayBgm(int index)
    {
        if(index < 0 || index >= bgmClips.Length)
        {
            Debug.Log("引数に指定した数が範囲外だよ");
            return;
        }
        bgmSource.clip = bgmClips[index];
        bgmSource.Play();
    }
    public void PlaySe(int index)
    {
        if(index < 0 || index >= seClips.Length)
        {
            Debug.Log("引数に指定した数が範囲外だよ");
            return;
        }
        seSource.clip = seClips[index];
        seSource.Play();
    }
    public void StopBgm()
    {
        bgmSource.Stop();
    }
}
