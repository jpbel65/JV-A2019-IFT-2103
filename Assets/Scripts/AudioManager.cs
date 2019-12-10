﻿using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundList;
    private static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound sound in soundList)
        {
            sound.SetAudioSource(gameObject.AddComponent<AudioSource>());
        }
        play("MainTheme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play(string nameSound)
    {
        foreach (Sound sound in soundList)
        {
            sound.Play(nameSound);
        }
    }

    private void stop(string nameSound)
    {
        foreach (Sound sound in soundList)
        {
            sound.Stop(nameSound);
        }
    }

    public void switchScene(string namePreviousSound, string nameNextSound)
    {
        foreach (Sound sound in soundList)
        {
            sound.Stop(namePreviousSound);
            sound.Play(nameNextSound);
        }
    }


}
