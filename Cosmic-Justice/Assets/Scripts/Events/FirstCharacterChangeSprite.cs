using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// JENNY LOOK AT THIS

public class FirstCharacterChangeSprite : MonoBehaviour
{
    private Image image;
    private NarrationCharacter character;
    private Sprite[] currentSprite;
    private float fps;

    private void Start()
    {
        image = GetComponent<Image>();

        //subscribe to the canvasShake event
        EventManager.current.character1SpriteChange += ChangeSprite;
        EventManager.current.setCharacter += SetCharacter;
    }

    private void OnDestroy()
    {
        //unsubscribe to the canvasShake event
        EventManager.current.character1SpriteChange -= ChangeSprite;
        EventManager.current.setCharacter -= SetCharacter;
    }

    private void SetCharacter(DialogueNode node)
    {
        if(node.DialogueLine.character1 != null)
            character = node.DialogueLine.character1;
    }

    private void ChangeSprite(DialogueNode node)
    {

        Sprite[] newSprite = GetSpriteFromName(node, node.DialogueLine.CharacterSprite1);

        if (newSprite.Equals(currentSprite))
            return;

        currentSprite = newSprite;

        if (newSprite.Length == 0)
        {
            Debug.Log("No sprites were given");
            return;
        }

        if (newSprite.Length <= 1)
        {
            StopAllCoroutines();
            image.sprite = newSprite[0];
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(LoopFrames(newSprite));
        }
    }

    IEnumerator LoopFrames(Sprite[] frames)
    {
        if (fps == 0)
            fps = 0.083f;

        float framesPerSecond = fps;

        while (true)
        {
            for(int i = 0; i < frames.Length; i++)
            {
                image.sprite = frames[i];
                yield return new WaitForSeconds(framesPerSecond);
            }
        }
    }

    //Function to get the sprite of the character based on the name of the sprite
    private Sprite[] GetSpriteFromName(DialogueNode node, string name)
    {
        Sprite[] returnSprite = null;

        for(int i = 0; i < character.sprites.Length; i++)
        {
            string compareName = character.sprites[i].name;
            if (string.Equals(name, compareName, System.StringComparison.CurrentCultureIgnoreCase))
            {
                returnSprite = character.sprites[i].sprite;

                if(character.sprites[i].FramesPerSecond != 0)
                    fps = (1000 / character.sprites[i].FramesPerSecond) / 1000;
                break;
            }
        }

        if (returnSprite != null)
        {
            return returnSprite;
        }
        else
        {
            Debug.Log("Could not find a sprite for the speaker with the name " + name + " at " + node.DialogueLine.ToString() + ". Please check to make sure the name is correct");
            return null;
        }
    }
}
