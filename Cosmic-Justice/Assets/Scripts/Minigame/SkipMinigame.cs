using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class SkipMinigame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private Image[] images;

    private List<DefaultSprites> sprites = new List<DefaultSprites>();

    [SerializeField]
    private Sprite standardizedSprite;

    private TMP_FontAsset standardizedFont;

    [SerializeField]
    private Button Yes, No;

    //The default sprites
    struct DefaultSprites
    {
        public Image obj;
        public Sprite sprite;

        public DefaultSprites(Image o, Sprite s)
        {
            obj = o; 
            sprite = s;
        }
    }

    private void Awake()
    {
        Yes.onClick.AddListener(YesClicked);
        No.onClick.AddListener(NoClicked);

        foreach (Image image in images)
        {
            sprites.Add(new DefaultSprites(image, image.sprite));
        }

        standardizedFont = SettingsSaver.instance.standardizedFont;

        EventManager.current.standardizeTextChanged += StandizeText;
        EventManager.current.darkModeChanged += DarkMode;
    }


    private void OnEnable()
    {
        StandizeText();
        DarkMode();
    }

    private void OnDestroy()
    {
        EventManager.current.standardizeTextChanged -= StandizeText;
        EventManager.current.darkModeChanged -= DarkMode;
    }

    private void StandizeText()
    {
        if (!SettingsSaver.instance.IsStandardized)
        {
            foreach (DefaultSprites s in sprites)
                s.obj.sprite = s.sprite;

            foreach (TextMeshProUGUI text in texts)
                text.color = Color.black;
        }
        else
        {
            foreach (Image image in images)
            {
                image.sprite = standardizedSprite;

            }

            foreach (TextMeshProUGUI text in texts)
            {
                text.font = standardizedFont;
            }

            if (SettingsSaver.instance.IsDarkModeText)
            {
                images[0].color = Color.black;
                images[1].color = Color.white;
                images[2].color = Color.white;

                texts[0].color = Color.white;
                texts[1].color = Color.black;
                texts[2].color = Color.black;
            }
            else
            {
                images[0].color = Color.white;
                images[1].color = Color.black;
                images[2].color = Color.black;

                texts[0].color = Color.black;
                texts[1].color = Color.white;
                texts[2].color = Color.white;
            }
        }
    }

    private void DarkMode()
    {
        if (!SettingsSaver.instance.IsStandardized)
            return;

        if (SettingsSaver.instance.IsDarkModeText)
        {
            images[0].color = Color.black;
            images[1].color = Color.white;
            images[2].color = Color.white;

            texts[0].color = Color.white;
            texts[1].color = Color.black;
            texts[2].color = Color.black;
        }
        else
        {
            images[0].color = Color.white;
            images[1].color = Color.black;
            images[2].color = Color.black;

            texts[0].color = Color.black;
            texts[1].color = Color.white;
            texts[2].color = Color.white;
        }
        
    }

    private void YesClicked()
    {
        MinigameManager.current.NoMinigameButtonClicked();
        gameObject.SetActive(false);
        MinigameManager.current.WaitForInput = false;
    }

    private void NoClicked()
    {

        MinigameManager.current.YesMinigameButtonClicked();
        gameObject.SetActive(false);
        MinigameManager.current.WaitForInput = false;
    }
}
