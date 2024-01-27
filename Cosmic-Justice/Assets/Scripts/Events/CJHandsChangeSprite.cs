using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CJHandsChangeSprite : MonoBehaviour
{
    private Image image;
    private Hands hands;
    private Sprite[] currentSprite;
    private float fps;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        EventManager.current.handsSpriteChange += ChangeSprite;
        EventManager.current.setCharacter += SetHands;
    }

    private void OnDestroy()
    {
        //unsubscribe to the canvasShake event
        EventManager.current.handsSpriteChange -= ChangeSprite;
        EventManager.current.setCharacter -= SetHands;
    }

    private void SetHands(DialogueNode node)
    {
        if (node.DialogueLine.hands != null)
            hands = node.DialogueLine.hands;
    }

    private void ChangeSprite(DialogueNode node)
    {

        Sprite[] newSprite = GetSpriteFromName(node, node.DialogueLine.CJHandsSprite);

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
            for (int i = 0; i < frames.Length; i++)
            {
                image.sprite = frames[i];
                yield return new WaitForSeconds(framesPerSecond);
            }
        }
    }

    private Sprite[] GetSpriteFromName(DialogueNode node, string name)
    {
        Sprite[] returnSprite = null;

        for (int i = 0; i < hands.sprites.Length; i++)
        {
            string compareName = hands.sprites[i].name;
            if (string.Equals(name, compareName, System.StringComparison.CurrentCultureIgnoreCase))
            {
                returnSprite = hands.sprites[i].sprite;

                if (hands.sprites[i].FramesPerSecond != 0)
                    fps = (1000 / hands.sprites[i].FramesPerSecond) / 1000;
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
