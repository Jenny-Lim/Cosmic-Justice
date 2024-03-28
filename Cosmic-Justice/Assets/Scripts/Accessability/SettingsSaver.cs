using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class SettingsSaver : MonoBehaviour
{
    public TMP_FontAsset standardizedFont;
    public TMP_FontAsset normalFont;

    // colorblind
    public Color[] replacingColors;
    string[] colorStrings = { "Red", "Green", "Blue", "Yellow", "Orange", "Purple", "Cyan", "Black", "White" };
    string[] colorStrings_r, colorStrings_g, colorStrings_b;

    public static SettingsSaver instance { get; private set; }

    //Identifiers for scripts to know if accessability is on
    [HideInInspector]
    public bool IsStandardized, IsDarkModeText, IsColorBlind;
    
    ///Setting the audio levels to max or loading saved levels
    [HideInInspector]
    public bool NewMusic, NewSFX;

    [SerializeField]
    private AudioMixer MusicMixer;
    //[SerializeField]
    //private AudioSource MusicAudioSource;

    public Slider MusicSlider;

    [SerializeField]
    private AudioMixer SFXMixer;
    //[SerializeField]
    //private AudioSource SFXAudioSource;

    public Slider SFXSlider;

    [SerializeField]
    private AudioMixMode MixMode;
    public enum AudioMixMode
    {
        LogrithmicMixerVolume
    }
    ///


    //The panel for standardized buttons
    public Sprite StandardPanel;

    PostEffectsController pec;

    //A list of the button sprites before they are changed from standization
    private List<ButtonDefaults> buttonDefaultSprites = new List<ButtonDefaults>();
    private List<TextMeshProUGUI> buttonTexts = new List<TextMeshProUGUI>();

    [SerializeField]
    private GameObject inputController;

    public InputActionAsset actions;

    //public EventManager eventManager;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        //If the playerprefs does not have a saved setting for standardized text then set it as no
        if (!PlayerPrefs.HasKey("StandardizedText"))
        {
            Debug.Log("test");
            PlayerPrefs.SetInt("StandardizedText", 0);
        }

        // Music saving
        if (!PlayerPrefs.HasKey("Music"))
        {
            Debug.Log("testmusic");
            PlayerPrefs.SetFloat("Music", 1);
        }

        // SFX saving
        if (!PlayerPrefs.HasKey("SFX"))
        {
            Debug.Log("testSFX");
            PlayerPrefs.SetFloat("SFX", 1);
        }


        // color blind

        pec = Camera.main.GetComponent<PostEffectsController>();
        replacingColors = new Color[9];

        if (!PlayerPrefs.HasKey("ColorBlind"))
        {
            PlayerPrefs.SetInt("ColorBlind", 0);
        }

        // names for playerpref
        colorStrings_r = new string[9];
        colorStrings_g = new string[9];
        colorStrings_b = new string[9];

        //must go through colors
        for (int i = 0; i < colorStrings.Length; i++)
        {
            // assign strings
            colorStrings_r[i] = colorStrings[i] + "_r";
            colorStrings_g[i] = colorStrings[i] + "_g";
            colorStrings_b[i] = colorStrings[i] + "_b";

            if (!PlayerPrefs.HasKey(colorStrings_r[i]))
            {
                PlayerPrefs.SetFloat(colorStrings_r[i], 1.0f);
            }
            if (!PlayerPrefs.HasKey(colorStrings_g[i]))
            {
                PlayerPrefs.SetFloat(colorStrings_g[i], 1.0f);
            }
            if (!PlayerPrefs.HasKey(colorStrings_b[i]))
            {
                PlayerPrefs.SetFloat(colorStrings_b[i], 1.0f);
            }

            replacingColors[i] = Color.white;
        }

        // end color blind

        GetButtonDefaults();

        //Load all playerpref settings
        LoadSettings();

        if (InputController.instance == null)
        {
            Instantiate(inputController);
        }
    }

    private void Start()
    {

        EventManager.current.sceneLoad += SceneTransitioned;
        EventManager.current.sceneWipe += ResetStandardize;
    }


    private void OnDestroy()
    {
        EventManager.current.sceneLoad -= SceneTransitioned;
        EventManager.current.sceneWipe -= ResetStandardize;
        ResetStandardize();
    }

    struct ButtonDefaults
    {
        public Button button;
        public Sprite sprite;

        public ButtonDefaults(Button b, Sprite s)
        {
            button = b;
            sprite = s;
        }
    }

    private void SceneTransitioned()
    {

        GetButtonDefaults();

        //Handles changing all texts into standardized texts
        if (IsStandardized)
        {
            StandardizeFonts(standardizedFont);
            DarkMode();
        }

        pec = Camera.main.GetComponent<PostEffectsController>();
        Debug.Log("isColorBlind" + IsColorBlind);
        if (IsColorBlind)
        {
            ColorBlind();
        }

    }


    // ------------------------------------------------------ //
    // -------------------Standardize Font------------------- //
    // ------------------------------------------------------ //

    private void GetButtonDefaults()
    {
        buttonDefaultSprites.Clear();
        buttonTexts.Clear();

        Button[] buttons = Resources.FindObjectsOfTypeAll<Button>();

        foreach (Button button in buttons)
        {
            if (button.tag != "NoStandardize")
            {
                if(button != null) 
                    if ( button.image != null)
                        buttonDefaultSprites.Add(new ButtonDefaults(button, button.image.sprite));

                TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();

                if (text != null)
                    buttonTexts.Add(text);
            }
            
        }

    }

    //Set if the accessibility setting of setting standardized text is on or off
    public void SetStandardizedText(int set)
    {
        PlayerPrefs.SetInt("StandardizedText", set);

        if (set == 0)
        {
            IsStandardized = false;
            StandardizeFonts(normalFont);
        }
        else
        {
            IsStandardized = true;
            StandardizeFonts(standardizedFont);
            DarkMode();
        }

        EventManager.current.StandardizeTextChanged();
    }

    //Set if the accessibility setting of setting standardized text is on or off
    public void SetDarkModeText(int set)
    {
        PlayerPrefs.SetInt("DarkModeText", set);

        if (set == 0)
        {
            IsDarkModeText = false;
            DarkMode();
        }
        else
        {
            IsDarkModeText = true;
            DarkMode();
        }

        EventManager.current.DarkModeChanged();
    }

    //Changes fonts and buttons of scenes on load
    private void StandardizeFonts(TMP_FontAsset font)
    {
        TextMeshProUGUI[] texts = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();

        Button[] buttons = Resources.FindObjectsOfTypeAll<Button>();

        foreach (TextMeshProUGUI text in texts)
        {
            text.font = font;
        }


        foreach (Button button in buttons)
        {
            if(button.tag != "NoStandardize")
                if(button.image != null)
                    button.image.sprite = StandardPanel;
        }
        
        if (font == normalFont)
            ResetStandardize();
    }

    //Changes fonts and buttons of scenes on load
    private void DarkMode()
    {
        if (!IsStandardized)
            return;

        Button[] buttons = Resources.FindObjectsOfTypeAll<Button>();

        foreach (Button button in buttons)
        {
            if (button.tag != "NoStandardize")
            {
                if (button.image != null)
                {
                    if (IsDarkModeText)
                        button.image.color = Color.black;
                    else
                        button.image.color = Color.white;
                }
            }
        }

        for(int i = 0; i < buttonTexts.Count; i++)
        {
            if (buttonTexts[i] != null)
            {

                if (IsDarkModeText)
                {
                    buttonTexts[i].color = Color.white;
                    //buttonTexts[i].text = buttonTexts[i].text;
                }
                else
                {
                    buttonTexts[i].color = Color.black;
                    //buttonTexts[i].text = buttonTexts[i].text;
                }
            }
        }

    }

    private void ResetStandardize()
    {

        foreach(ButtonDefaults buttonDefaults in buttonDefaultSprites)
        {
            if (buttonDefaults.button != null)
                if (buttonDefaults.button.image != null)
                {
                    buttonDefaults.button.image.sprite = buttonDefaults.sprite;
                    buttonDefaults.button.image.color = Color.white;
                }
        }

        for (int i = 0; i < buttonTexts.Count; i++)
        {
            if (buttonTexts[i] != null)
            {
                 buttonTexts[i].color = Color.white;
            }
        }
    }

        // ------------------------------------------------------ //
        // -------------------Color Blind Mode------------------- //
        // ------------------------------------------------------ //

    public void SetColorBlind(bool isColorBlind)
    {
        if (isColorBlind)
        {
            PlayerPrefs.SetInt("ColorBlind", 1);
            SetColors();
        }

        else PlayerPrefs.SetInt("ColorBlind", 0);

        IsColorBlind = isColorBlind;
        pec.enabled = isColorBlind;
    }

    public void SetColors()
    {
        for (int i = 0; i < colorStrings.Length; i++)
        {
            PlayerPrefs.SetFloat(colorStrings_r[i], replacingColors[i].r);
            PlayerPrefs.SetFloat(colorStrings_g[i], replacingColors[i].g);
            PlayerPrefs.SetFloat(colorStrings_b[i], replacingColors[i].b);
        }
        ColorBlind();
    }

    public void ColorBlind()
    {
        if (IsColorBlind)
        {
            for (int i = 0; i < 9; i++)
            {
                replacingColors[i] = new Color(PlayerPrefs.GetFloat(colorStrings_r[i]), PlayerPrefs.GetFloat(colorStrings_g[i]), PlayerPrefs.GetFloat(colorStrings_b[i]), 1.0f);
                Debug.Log("col: " + replacingColors[i]);
                pec.enabled = true;
            }
        }
        else
        {
            pec.enabled = false;
        }
    }

    // ------------------------------------------------------ //
    // -------------------Audio Settings--------------------- //
    // ------------------------------------------------------ //


    public void SetMusic(float value)
    {

        if (value == 0.0001)
            return;

        PlayerPrefs.SetFloat("Music", value);

        if (value == 1)
        {
            NewMusic = true;
            Music(value);
        }
        else
        {
            NewMusic = false;
            Music(value);
        }

        if(EventManager.current != null)
            EventManager.current.MusicChanged();
    }

    private void Music(float value)
    {
        if (NewMusic == true)
        {
            switch (MixMode)
            {
                case AudioMixMode.LogrithmicMixerVolume:
                    MusicMixer.SetFloat("Volume", Mathf.Log10(1) * 20);
                    break;
            }
            NewMusic = false;
        }
        else
        {
            switch (MixMode)
            {
                case AudioMixMode.LogrithmicMixerVolume:
                    MusicMixer.SetFloat("Volume", Mathf.Log10(value) * 20);
                    break;
            }
            
        }
    }

    public void MusicOnChangeSlider()
    {
        float Value = MusicSlider.value;
        switch (MixMode)
        {
            case AudioMixMode.LogrithmicMixerVolume:
                MusicMixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
                break;
        }

        SetMusic(Value);
    }

    private void SFX()
    {

    }


    // ------------------------------------------------------ //
    // -------------------Load Settings---------------------- //
    // ------------------------------------------------------ //

    private void LoadSettings()
    {
        int standardize = PlayerPrefs.GetInt("StandardizedText");

        if (standardize == 0)
        {
            IsStandardized = false;
            StandardizeFonts(normalFont);
        }
        else
        {
            IsStandardized = true;
            StandardizeFonts(standardizedFont);
        }

        int darkMode = PlayerPrefs.GetInt("DarkModeText");

        if (darkMode == 0)
        {
            IsDarkModeText = false;
            DarkMode();
        }
        else
        {
            IsDarkModeText = true;
            DarkMode();
        }

        int colorBlind = PlayerPrefs.GetInt("ColorBlind");
        if (colorBlind == 0)
        {
            IsColorBlind = false;
        }
        else
        {
            IsColorBlind = true;
        }
        ColorBlind();

        float music = PlayerPrefs.GetInt("Music");

        if(music == 1)
        {
            NewMusic = true;
            Music(music);
            MusicSlider.value = 1;
        }
        else
        {
            NewMusic = false;
            Music(music);
            MusicSlider.value = music;
        }
    }
}
