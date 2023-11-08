using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Line")]
public class NarrationLine : ScriptableObject
{

    [SerializeField]
    private NarrationCharacter m_Speaker; //holds the speaker of the line

    [SerializeField]
    private NarrationCharacter m_Listener; //holds the one being spoken to of the line

    [Header("Dialogue Text Manipulation")]
    [SerializeField]
    [TextArea]
    private string m_Text; //Holds the line of text being spoken

    [SerializeField]
    private float m_FontSize = 20f;

    [SerializeField]
    [Range(0f, 10f)]
    private float m_TextSpeed = 0.1f;


    [Header("Speaker Manipulation")]
    /*
    [SerializeField]
    private Sprite m_CharacterImage1; //Holds the image of the character during this dialogue

    [SerializeField]
    private Sprite m_CharacterImage2;*/

    [SerializeField]
    private String m_CharacterSprite1;

    [SerializeField]
    private String m_CharacterSprite2;

    [Header("Events and Minigames")]
    [SerializeField]
    private Events m_events;

    [SerializeField]
    private Minigames m_minigames;

    [Flags]
    public enum Events
    {
        ShakeCanvas = 1,
        Character1SpriteChange = 2,
        Character2SpriteChange = 4
    }

    public enum Minigames
    {
        Asteroid = 1,
    }

    public NarrationCharacter Speaker => m_Speaker; //Gets speaker's name
    public NarrationCharacter Listener => m_Listener;

    public string Text => m_Text; //Gets the dialogue text

    //public Sprite CharacterImage1 => m_CharacterImage1; //A public access for the first character image

    //public Sprite CharacterImage2 => m_CharacterImage2; //A public access for the second character image

    public Events events => m_events;

    public Minigames minigame => m_minigames;

    public float TextSpeed => m_TextSpeed;

    public float FontSize => m_FontSize;

    public string CharacterSprite1 => m_CharacterSprite1;

    public string CharacterSprite2 => m_CharacterSprite2;

    /*
    public UnityEvent LineEvent => m_LineEvent; //Gets the events associated with this dialogue
    */

}
