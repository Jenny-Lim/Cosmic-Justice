using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;


public class DialogueText : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private string text;

    private float textSpeed = 0.1f; //Is how long it takes for the next letter to be written

    private bool textOver;
    private bool speedText;

    private bool canSpeedUp;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = string.Empty;
        textOver = true;
        speedText = false;
        canSpeedUp = true;
    }

    private void OnEnable()
    {
        //Empties text every time it is enabled
        textMeshProUGUI.text = string.Empty;
        textOver = false;
    }

    private void Start()
    {
        EventManager.current.click += FastDialogue;
        EventManager.current.canDialogue += CanSpeedDialogue;
    }

    private void OnDestroy()
    {
        EventManager.current.click -= FastDialogue;
        EventManager.current.canDialogue -= CanSpeedDialogue;
    }

    private void CanSpeedDialogue(bool can)
    {
        canSpeedUp = can;
    }

    IEnumerator TypeLine()
    {
        Color defCol = textMeshProUGUI.color;

        string hexCol = ColorUtility.ToHtmlStringRGB(defCol);

        textOver = false;

        bool richText = false;
        string richT = "";

        //loop throuogh each char in text and print letter by letter. Wait for textSpeed amount of time before writing the next letter
        foreach (char c in text.ToCharArray())
        {
            //If the char c is the start of a rich text
            if(c == '<')
            {
                richText = true;

            }

            //If there is a richText in the text
            if (richText)
            {
                if (c == '>')
                {
                    richT += c;

                    if (!richT.Equals("<color=\"default\">"))
                    {
                        textMeshProUGUI.text += richT;
                        richT = "";
                    }
                    else
                    {
                        richT = "";
                        textMeshProUGUI.text += "<color=#" + hexCol + ">";
                    }
                    richText = false;
                }
                else
                {
                    richT += c;
                }

            }
            else if(!richText)
            {
                textMeshProUGUI.text += c;
                if(textSpeed != 0)
                    yield return new WaitForSeconds(textSpeed);
            }

        }

        AudioManager.instance.CharacterDoneSpeaking();
        textOver = true;

        if (speedText)
        {
            EventManager.current.DialogueClick(true);
        }
      

    }


    //Method to start dialogue and set font, size, and speed
    public void startDialogue(string line, float speed, TMP_FontAsset font, float size, Color color, AudioClip voice)
    {
        speedText = false;
        textMeshProUGUI.text = string.Empty; //Empty the text
        textMeshProUGUI.font = font;
        textMeshProUGUI.fontSize = size;
        textMeshProUGUI.color = color;
        text = line;
        textSpeed = speed;
        AudioManager.instance.PlayCharacterSpeaking(voice);
       
        //Start typing the dialogue
        StartCoroutine(TypeLine());
    }

    private void FastDialogue()
    {
        if (!textOver && canSpeedUp)
        {
            EventManager.current.DialogueClick(false);
            textSpeed = 0.00001f;
            speedText = true;
        }
    }
}
