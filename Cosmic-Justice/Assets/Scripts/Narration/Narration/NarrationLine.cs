using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Line")]
public class NarrationLine : ScriptableObject
{

    [SerializeField]
    private NarrationCharacter m_Speaker; //holds the speaker of the line

    [SerializeField]
    [Multiline]
    private string m_Text; //Holds the line of text being spoken

    [SerializeField]
    private Sprite m_CharacterImage; //Holds the image of the character during this dialogue

    /*
    [SerializeField]
    private UnityEvent m_LineEvent; //Holds events that are to be played during this dialogue
    */

    [Flags]
    public enum Events
    {
        ShakeCanvas = 1,
        Character1SpriteChange = 2
    }

    public enum Minigames
    {
        Asteroid = 1,
    }

    [SerializeField]
    private Events m_events;

    [SerializeField]
    private Minigames m_minigames;

    public NarrationCharacter Speaker => m_Speaker; //Gets speaker's name
    public string Text => m_Text; //Gets the dialogue text

    public Sprite CharacterImage => m_CharacterImage; //A public access for the character image

    public Events events => m_events;

    public Minigames minigame => m_minigames;

    /*
    public UnityEvent LineEvent => m_LineEvent; //Gets the events associated with this dialogue
    */

}
