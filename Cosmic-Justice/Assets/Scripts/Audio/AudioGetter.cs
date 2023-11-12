using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGetter : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void PlayAudio(string audioName)
    {
        if(audioManager)
            audioManager.Play(audioName);
        else
            print("AudioManager Not Found.");
    }
}
