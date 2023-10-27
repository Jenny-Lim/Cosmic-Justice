using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DialogueText : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private string text;

    private float textSpeed = 0.1f; //Is how long it takes for the next letter to be written

    private bool textOver;
    private bool speedText;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = string.Empty;
        textOver = true;
        speedText = false;
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
    }

    private void OnDestroy()
    {
        EventManager.current.click -= FastDialogue;
    }


    IEnumerator TypeLine()
    {
        textOver = false;

        //loop throuogh each char in text and print letter by letter. Wait for textSpeed amount of time before writing the next letter
        foreach (char c in text.ToCharArray())
        {
            textMeshProUGUI.text += c;
            yield return new WaitForSeconds(textSpeed);

        }

        textOver = true;

        if (speedText)
        {
            EventManager.current.DialogueClick(true);
        }
      

    }


    public void startDialogue(string line, float speed, TMP_FontAsset font, float size)
    {
        speedText = false;
        textMeshProUGUI.text = string.Empty; //Empty the text
        textMeshProUGUI.font = font;
        textMeshProUGUI.fontSize = size;
        text = line;
        textSpeed = speed;
       
        //Start typing the dialogue
        StartCoroutine(TypeLine());
    }

    private void FastDialogue()
    {
        if (!textOver)
        {
            EventManager.current.DialogueClick(false);
            textSpeed = 0;
            speedText = true;
        }
    }
}
