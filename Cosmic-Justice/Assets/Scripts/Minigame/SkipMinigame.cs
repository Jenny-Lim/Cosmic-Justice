using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkipMinigame : MonoBehaviour
{
    private TextMeshProUGUI[] texts;
    private Image[] images;

    private Sprite[] sprites;

    [SerializeField]
    private Sprite standardizedSprite;

    private TMP_FontAsset standardizedFont;

    [SerializeField]
    private Button Yes, No;


    private void OnEnable()
    {

        texts = GetComponentsInChildren<TextMeshProUGUI>();
        images = GetComponentsInChildren<Image>();
        //sprites = GetComponentsInChildren<Sprite>();

        standardizedFont = SettingsSaver.instance.standardizedFont;

        if (!SettingsSaver.instance.IsStandardized)
        {

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
                text.color = Color.black;
            }
        }

        Yes.onClick.AddListener(YesClicked);
        No.onClick.AddListener(NoClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void YesClicked()
    {
        MinigameManager.current.YesMinigameButtonClicked();
        gameObject.SetActive(false);
        MinigameManager.current.WaitForInput = false;
    }

    private void NoClicked()
    {
        MinigameManager.current.NoMinigameButtonClicked();
        gameObject.SetActive(false);
        MinigameManager.current.WaitForInput = false;
    }
}
