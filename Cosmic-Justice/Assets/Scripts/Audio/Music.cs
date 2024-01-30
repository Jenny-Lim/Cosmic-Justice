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

    private float MusicVolumeSaved;

    public Slider MusicSlider;

    [SerializeField] private Slider volumeSlider;
    public void OnChangeSlider(float Value)
    {

        switch (MixMode)
        {
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);

                PlayerPrefs.SetFloat("MusicVolume", Value);


                //sceneLoader.SetMusicVolume(Value);

                break;
        }
    }

    private void Start()
    {
        //GetSceneLoader();

        MusicVolumeSaved = PlayerPrefs.GetFloat("MusicVolume");
        Mixer.SetFloat("Volume", Mathf.Log10(MusicVolumeSaved) * 20);
        MusicSlider.value = MusicVolumeSaved;

        //volumeSlider.value = sceneLoader.GetMusicVolume();
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
