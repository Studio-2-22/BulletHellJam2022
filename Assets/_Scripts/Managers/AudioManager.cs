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
        SFX[index].Play();
    }

    public void PlayMusic(int index)
    {
        Music[index].Play();
    }

    public void PlayeEffect(int index)
    {
        float pitch = Random.Range(0.9f, 1);
        SFX[index].pitch = pitch;
        SFX[index].Play();
        SFX[index].pitch = pitch;
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
