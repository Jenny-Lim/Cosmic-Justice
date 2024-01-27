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

    private SceneLoader sceneLoader;


    [SerializeField] private Slider volumeSlider;
    public void OnChangeSlider(float Value)
    {

        switch (MixMode)
        {
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);

                sceneLoader.SetMusicVolume(Value);

                break;
        }
    }

    private void Start()
    {
        GetSceneLoader();

        volumeSlider.value = sceneLoader.GetMusicVolume();
        Mixer.SetFloat("Volume", Mathf.Log10(volumeSlider.value) * 20);
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
