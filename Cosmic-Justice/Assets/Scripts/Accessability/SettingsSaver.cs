using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsSaver : MonoBehaviour
{
    public TMP_FontAsset standardizedFont;
    public TMP_FontAsset normalFont;

    public Color[] replacingColors;

    public static SettingsSaver instance { get; private set; }


    //Identifiers for scripts to know if accessability is on
    [HideInInspector]
    public bool IsStandardized, IsDarkModeText, IsColorBlind;

    //The panel for standardized buttons
    public Sprite StandardPanel;

    PostEffectsController pec;

    //A list of the button sprites before they are changed from standization
    private List<ButtonDefaults> buttonDefaultSprites = new List<ButtonDefaults>();
    private List<TextMeshProUGUI> buttonTexts = new List<TextMeshProUGUI>();

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

        pec = Camera.main.GetComponent<PostEffectsController>();

        replacingColors = new Color[9];
        for (int i = 0; i < 9; i++)
        {
            replacingColors[i] = Color.white;
        }

        //If the playerprefs does not have a saved setting for standardized text then set it as no
        if (!PlayerPrefs.HasKey("StandardizedText"))
        {
            Debug.Log("test");
            PlayerPrefs.SetInt("StandardizedText", 0);
        }

        if (!PlayerPrefs.HasKey("ColorBlind"))
        {
            PlayerPrefs.SetInt("ColorBlind", 0);
        }

        //must go through colors

        GetButtonDefaults();

        //Load all playerpref settings
        LoadSettings();

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
        SetColorBlind(IsColorBlind);

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
                if (IsDarkModeText)
                    if(button.image != null)
                        button.image.color = Color.black;
                else
                    if (button.image != null)
                        button.image.color = Color.white;
            }
        }

        for(int i = 0; i < buttonTexts.Count; i++)
        {
            if (buttonTexts[i] != null)
            {

                if (IsDarkModeText)
                {
                    buttonTexts[i].color = Color.white;
                    buttonTexts[i].text = buttonTexts[i].text;
                }
                else
                {
                    buttonTexts[i].color = Color.black;
                    buttonTexts[i].text = buttonTexts[i].text;
                }
            }
        }

    }

    private void ResetStandardize()
    {

        foreach(ButtonDefaults buttonDefaults in buttonDefaultSprites)
        {
            if(buttonDefaults.button != null)
                if (buttonDefaults.button.image != null)
                    buttonDefaults.button.image.sprite = buttonDefaults.sprite;
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
        if(isColorBlind) PlayerPrefs.SetInt("ColorBlind", 1);
        else PlayerPrefs.SetInt("ColorBlind", 0);
        IsColorBlind = isColorBlind;
        pec.enabled = isColorBlind;
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
        SetColorBlind(IsColorBlind);
    }
}
