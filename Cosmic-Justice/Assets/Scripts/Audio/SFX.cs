using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFX : MonoBehaviour
{

    [SerializeField]
    private AudioMixer Mixer;
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private AudioMixMode MixMode;


    [SerializeField] private Slider volumeSlider;

    private SceneLoader sceneLoader;

    private float SFXVolumeSaved;

    public Slider SFXSlider;

    public void OnChangeSlider(float Value)
    {

        switch (MixMode)
        {
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);

                PlayerPrefs.SetFloat("SFXVolume", Value);

                //sceneLoader.SetMusicVolume(Value);

                break;
        }
    }

    private void Start()
    {
        //GetSceneLoader();

        SFXVolumeSaved = PlayerPrefs.GetFloat("SFXVolume");
        Mixer.SetFloat("Volume", Mathf.Log10(SFXVolumeSaved) * 20);
        SFXSlider.value = SFXVolumeSaved;

        //volumeSlider.value = sceneLoader.GetSFXVolume();
        //Mixer.SetFloat("Volume", Mathf.Log10(volumeSlider.value) * 20);
    }


    private void GetSceneLoader()
    {
        if(sceneLoader == null) 
            sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public enum AudioMixMode
    {
        LogrithmicMixerVolume
    }
}
