using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsSaver : MonoBehaviour
{
    public TMP_FontAsset standardizedFont;
    public TMP_FontAsset normalFont;

    public static SettingsSaver instance { get; private set; }

    [HideInInspector]
    public bool IsStandardized;

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

        //Load all playerpref settings
        LoadSettings();

        EventManager.current.sceneLoad += SceneTransitioned;
    }

    private void OnDestroy()
    {
        EventManager.current.sceneLoad -= SceneTransitioned;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SceneTransitioned()
    {
        Debug.Log("transfer");
        //Handles changing all texts into standardized texts
        if (IsStandardized)
        {
            ChangeFonts(standardizedFont);
        }
    }

    //Set if the accessibility setting of setting standardized text is on or off
    public void SetStandardizedText(int set)
    {
        PlayerPrefs.SetInt("StandardizedText", set);

        if (set == 0)
        {
            IsStandardized = false;
            ChangeFonts(normalFont);
        }
        else
        {
            IsStandardized = true;
            ChangeFonts(standardizedFont);
        }
    }

    private void ChangeFonts(TMP_FontAsset font)
    {
        TextMeshProUGUI[] texts = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();

        foreach (TextMeshProUGUI text in texts)
        {
            text.font = font;
        }
    }

    private void LoadSettings()
    {
        int standardize = PlayerPrefs.GetInt("StandardizedText");

        if (standardize == 0)
        {
            IsStandardized = false;
            ChangeFonts(normalFont);
        }
        else
        {
            IsStandardized = true;
            ChangeFonts(standardizedFont);
        }
    }
}
