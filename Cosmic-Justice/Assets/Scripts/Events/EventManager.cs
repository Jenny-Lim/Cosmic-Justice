using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //One instance of the class
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    private DialogueNode node;

    public void GetNode(DialogueNode saveNode)
    {
        node = saveNode;
    }

    //---------------------- Events --------------------------//

    public event Action<DialogueNode> canvasShake;
    public void ShakeCanvas()
    {
        canvasShake?.Invoke(node);
    }

    public event Action<DialogueNode> character1SpriteChange;
    public void Character1SpriteChange()
    {
        character1SpriteChange?.Invoke(node);
    }

    public event Action<DialogueNode> character2SpriteChange;
    public void Character2SpriteChange()
    {
        character2SpriteChange?.Invoke(node);
    }

    public event Action asteroid;
    public void Asteroid()
    {
        asteroid?.Invoke();
    }

    public event Action endAsteroid;
    public void EndAsteroid()
    {
        endAsteroid?.Invoke();
    }

    public event Action<bool> canDialogue;
    public void CanDialogue(bool can)
    {
        canDialogue?.Invoke(can);
    }
}
