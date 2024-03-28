using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private List<Sound> currentlyPlayingSounds;

    private Sound characterSpeak;

    private bool characterSpeaking;

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
    }

    private void Start()
    {
        currentlyPlayingSounds = new List<Sound>();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.outputAudioMixerGroup = s.mixer;
        }

        characterSpeaking = false;

        if (SceneManager.GetActiveScene().buildIndex != 2)
            Play("MainTheme");
        else
            Play("Ambient_Track_A");

        characterSpeak = Array.Find(sounds, sound => sound.name == "CharacterSpeaking");
    }

    //Plays a sound based on a name
    public void Play(string name)
    {

        if (name == "Nothing" || string.IsNullOrEmpty(name))
            return;

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
            if(!s.canOverlap)
                currentlyPlayingSounds.Add(s); //Sound is now playing so add it
            s.source.Play();
        }
    }

    //Stops playing a sound based on a name
    public void Stop(string name)
    {
        if (name == "Nothing" || string.IsNullOrEmpty(name))
            return;

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        currentlyPlayingSounds.Remove(s);

        if(s.source != null)
            s.source.Stop();
    }

    //Pause a sound based on a name
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

    //Unpause a sound based on a name
    public void UnPause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.UnPause();
    }

    public void PlayCharacterSpeaking(AudioClip clip)
    {
        if (clip == null)
            return;

        characterSpeaking = true;

        characterSpeak.source.clip = clip;

        characterSpeak.source.pitch = UnityEngine.Random.Range(0.5f, 3f);
        characterSpeak.source.Play();

        StartCoroutine(Speaking());
    }

    private IEnumerator Speaking()
    {
        float clipLength = characterSpeak.source.clip.length;

        while (characterSpeaking)
        {
            yield return new WaitForSeconds(clipLength);

            characterSpeak.source.pitch = UnityEngine.Random.Range(0.5f, 3f);
            characterSpeak.source.Play();
        }
    }

    public void CharacterDoneSpeaking()
    {
        characterSpeaking = false;
    }
}
