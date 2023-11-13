using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGetter : MonoBehaviour
{

    public void PlayAudio(string audioName)
    {
        AudioManager.instance.Play(audioName);
    }
}
