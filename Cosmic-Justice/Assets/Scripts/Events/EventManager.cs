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
        if(canvasShake != null)
        {
            canvasShake(node);
        }
    }

    public event Action<DialogueNode> character1SpriteChange;
    public void Character1SpriteChange()
    {
        if(character1SpriteChange != null)
        {
            character1SpriteChange(node);
        }
    }

    public event Action asteroid;
    public void Asteroid()
    {
        if(asteroid != null)
        {
            asteroid();
        }
    }
}
