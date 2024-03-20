using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundsManager_R : MonoBehaviour
{
    public Sound_R[] musicSounds, SfxSounds;
    public AudioSource musicSource, SfxSource;

    public static SoundsManager_R Instance_RS;

    private void Awake()
    {
        if (Instance_RS == null)
        {
            Instance_RS = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic("Bgm");
    }
    public void PlayMusic(string name)
    {
        Sound_R s = Array.Find(musicSounds, x => x.name == name);
        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void SfxPlay(string name)
    {
        Sound_R s = Array.Find(SfxSounds, x => x.name == name);
        if (s != null)
        {
            SfxSource.PlayOneShot(s.clip);
        }
    }
}
