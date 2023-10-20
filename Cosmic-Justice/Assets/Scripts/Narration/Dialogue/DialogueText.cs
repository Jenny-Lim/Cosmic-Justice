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

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = string.Empty;
    }

    private void OnEnable()
    {
        //Empties text every time it is enabled
        textMeshProUGUI.text = string.Empty;
    }


    IEnumerator TypeLine()
    {
        //loop throuogh each char in text and print letter by letter. Wait for textSpeed amount of time before writing the next letter
        foreach (char c in text.ToCharArray())
        {
            textMeshProUGUI.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }


    public void startDialogue(string line, float speed, TMP_FontAsset font)
    {
        textMeshProUGUI.text = string.Empty; //Empty the text
        textMeshProUGUI.font = font;
        text = line;
        textSpeed = speed;
       
        //Start typing the dialogue
        StartCoroutine(TypeLine());
    }
}
