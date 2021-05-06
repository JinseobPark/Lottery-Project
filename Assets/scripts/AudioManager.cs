﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundBox
{
    public GameObject Intro_Object;
    public GameObject BGM_Object;
    public GameObject Button_Object;
    public GameObject Fail_Object;
    public AudioClip Button_sound;
    public AudioClip Fail_sound;
}

public class AudioManager : MonoBehaviour
{

    public static SoundBox g_soundbox = new SoundBox();
    public static AudioManager _audio_instance;

    public static AudioManager Audio_Instance
    {
        get
        {
            if (_audio_instance == null)
            {
                _audio_instance = FindObjectOfType(typeof(AudioManager)) as AudioManager;
                if (_audio_instance == null)
                {
                    Debug.LogError("there needs to be one active Global script");
                }
            }
            return _audio_instance;
        }
    }
    void Awake()
    {
        var obj = FindObjectsOfType<AudioManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        g_soundbox.Intro_Object  = GameObject.Find("Intro_source");
        g_soundbox.BGM_Object    = GameObject.Find("BGM_source");
        g_soundbox.Button_Object = GameObject.Find("Button_source");
        g_soundbox.Fail_Object   = GameObject.Find("Fail_source");
        g_soundbox.Button_sound  = g_soundbox.Button_Object.GetComponent<AudioSource>().clip;
        g_soundbox.Fail_sound    = g_soundbox.Fail_Object.GetComponent<AudioSource>().clip;
        PlayIntroSound();
    }
    public void PlayIntroSound()
    {
        if (OptionData.g_optiondata.GetSoundIsTrue())
            g_soundbox.Intro_Object.GetComponent<AudioSource>().Play();
    }
    public void PlayBGMSound()
    {
        g_soundbox.BGM_Object.GetComponent<AudioSource>().Play();
    }
    public void StopBGMSound()
    {
        g_soundbox.BGM_Object.GetComponent<AudioSource>().Stop();
    }
    public bool IsPlayBGM()
    {
        return g_soundbox.BGM_Object.GetComponent<AudioSource>().isPlaying;
    }
    public void PlayButtonSound()
    {
        if (OptionData.g_optiondata.GetSoundIsTrue())
            g_soundbox.BGM_Object.GetComponent<AudioSource>().PlayOneShot(g_soundbox.Button_sound);
    }
    public void PlayFailSound()
    {
        if (OptionData.g_optiondata.GetSoundIsTrue())
            g_soundbox.Fail_Object.GetComponent<AudioSource>().PlayOneShot(g_soundbox.Fail_sound);
    }
    public void PlayWinSound(int prize)
    {
        const int ThreeMatch = 5000;
        const int FourMatch = 50000;
        const int FiveMatch = 1000000;
        const int BonusMatch = 50000000;
        const int SixMatch = 2000000000;
        if (prize >= SixMatch) PlayFailSound();
        else if (prize >= BonusMatch) PlayFailSound();
        else if (prize >= FiveMatch)  PlayFailSound();
        else if (prize >= FourMatch)  PlayFailSound();
        else if (prize >= ThreeMatch) PlayFailSound();
        else
        {
            PlayFailSound();
        }
    }
    //AudioManager.Audio_Instance.PlayButtonSound();
}