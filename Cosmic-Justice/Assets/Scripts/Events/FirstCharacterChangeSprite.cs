using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstCharacterChangeSprite : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();

        //subscribe to the canvasShake event
        EventManager.current.character1SpriteChange += ChangeSprite;
    }

    private void OnDestroy()
    {
        //unsubscribe to the canvasShake event
        EventManager.current.character1SpriteChange -= ChangeSprite;
    }

    private void ChangeSprite(DialogueNode node)
    {
        image.sprite = node.DialogueLine.CharacterImage;
    }
}
