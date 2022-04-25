using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] SFX;
    public AudioSource[] Music;

   void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(int index)
    {
        SFX[index].pitch = 1f;
        SFX[index].Play();
    }

    public void PlayMusic(int index)
    {
        //stop all music
        foreach (AudioSource a in Music)
        {
            a.Stop();
        }
        Music[index].Play();
    }

    public void PlayEffect(int index)
    {
        float pitch = Random.Range(0.9f, 1);
        SFX[index].pitch = pitch;
        SFX[index].Play();

    }

    public void PlayPitchedEffect(int index, float pitch)
    {
        SFX[index].pitch = pitch;
        SFX[index].Play();

    }

    public void StopMusic(int index)
    {
        Music[index].Stop();
    }

    public void StopAllMusic()
    {
        foreach (AudioSource audio in Music)
        {
            audio.Stop();
        }
    }

    public void StopAllSFX()
    {
        foreach (AudioSource audio in SFX)
        {
            audio.Stop();
        }
    }

    public void StopAll()
    {
        StopAllMusic();
        StopAllSFX();
    }

    public void PauseAll()
    {
        foreach (AudioSource audio in Music)
        {
            audio.Pause();
        }
        foreach (AudioSource audio in SFX)
        {
            audio.Pause();
        }
    }

    public void UnPauseAll()
    {
        foreach (AudioSource audio in Music)
        {
            audio.UnPause();
        }
        foreach (AudioSource audio in SFX)
        {
            audio.UnPause();
        }
    }




}
