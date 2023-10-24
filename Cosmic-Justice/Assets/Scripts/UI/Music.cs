using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Music : MonoBehaviour
{

    [SerializeField]
    private AudioMixer Mixer;
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private AudioMixMode MixMode;


    [SerializeField] private Slider volumeSlider;
    public void OnChangeSlider(float Value)
    {

        switch (MixMode)
        {
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
                GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>().SetMusicVolume(Value);
                break;
        }
    }

    private void Start()
    {

        volumeSlider.value = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>().GetMusicVolume();
        Mixer.SetFloat("Volume", Mathf.Log10(volumeSlider.value) * 20);
    }

    public enum AudioMixMode
    {
        LogrithmicMixerVolume
    }
}
