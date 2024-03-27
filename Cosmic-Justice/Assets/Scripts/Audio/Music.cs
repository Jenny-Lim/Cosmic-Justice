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


    public Slider MusicSlider;
    public void OnChangeSlider(float Value)
    {

        switch (MixMode)
        {
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);

                SettingsSaver.instance.SetMusic(1);
                break;
        }
    }

    private void Start()
    {

        //MusicVolumeSaved = PlayerPrefs.GetFloat("MusicVolume");
        //Mixer.SetFloat("Volume", Mathf.Log10(MusicVolumeSaved) * 20);
        //MusicSlider.value = MusicVolumeSaved;
    }

    public enum AudioMixMode
    {
        LogrithmicMixerVolume
    }
}
