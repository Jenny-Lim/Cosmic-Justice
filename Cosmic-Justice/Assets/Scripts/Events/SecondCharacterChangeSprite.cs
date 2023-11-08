using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondCharacterChangeSprite : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();

        //subscribe to the canvasShake event
        EventManager.current.character2SpriteChange += ChangeSprite;
    }

    private void OnDestroy()
    {
        //unsubscribe to the canvasShake event
        EventManager.current.character2SpriteChange -= ChangeSprite;
    }

    private void ChangeSprite(DialogueNode node)
    {
        Sprite newSprite = GetSpriteFromName(node, node.DialogueLine.CharacterSprite2);

        image.sprite = newSprite;
    }

    //Function to get the sprite of the character based on the name of the sprite
    private Sprite GetSpriteFromName(DialogueNode node, string name)
    {

        Sprite returnSprite = null;

        for (int i = 0; i < node.DialogueLine.Listener.sprites.Length; i++)
        {
            if (node.DialogueLine.Listener.sprites[i].name == name)
            {
                returnSprite = node.DialogueLine.Listener.sprites[i].sprite;
                break;
            }
        }

        if (returnSprite != null)
        {
            return returnSprite;
        }
        else
        {
            Debug.Log("Could not find a sprite with the name " + name + ". Please check to make sure the name is correct");
            return null;
        }
    }
}
