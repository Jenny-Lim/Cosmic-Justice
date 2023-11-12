using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class SecondCharacterChangeSprite : MonoBehaviour
{
    private Image image;
    private NarrationCharacter character;

    private void Start()
    {
        image = GetComponent<Image>();

        //subscribe to the canvasShake event
        EventManager.current.character2SpriteChange += ChangeSprite;
        EventManager.current.setCharacter += SetCharacter;
    }

    private void OnDestroy()
    {
        //unsubscribe to the canvasShake event
        EventManager.current.character2SpriteChange -= ChangeSprite;
        EventManager.current.setCharacter -= SetCharacter;
    }

    private void SetCharacter(DialogueNode node)
    {
        character = node.DialogueLine.Listener;
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
            string compareName = node.DialogueLine.Listener.sprites[i].name;
            if (string.Equals(name, compareName, System.StringComparison.CurrentCultureIgnoreCase))
            {
                returnSprite = character.sprites[i].sprite;
                break;
            }
        }

        if (returnSprite != null)
        {
            return returnSprite;
        }
        else
        {
            Debug.Log("Could not find a sprite for the listener with the name " + name + " at " + node.DialogueLine.ToString() + ". Please check to make sure the name is correct");
            return null;
        }
    }
}
