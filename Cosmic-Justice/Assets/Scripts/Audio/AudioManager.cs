using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private List<Sound> currentlyPlayingSounds;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        currentlyPlayingSounds = new List<Sound>();

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.outputAudioMixerGroup = s.mixer;
        }
    }

    private void Start()
    {
        Play("MainTheme");
    }

    //Plays a sound based on a name
    public void Play(string name)
    {
        //Find the sound if it is there
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        //Ensure playing of the sound is done only when the sound is not currently being played
        if (!currentlyPlayingSounds.Contains(s))
        {
            currentlyPlayingSounds.Add(s); //Sound is now playing so add it
            s.source.Play();
        }
    }

    //Stops playing a sound based on a name
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        currentlyPlayingSounds.Remove(s);
        s.source.Stop();
    }
}
