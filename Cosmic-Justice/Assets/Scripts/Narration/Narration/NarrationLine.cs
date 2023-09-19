using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Line")]
public class NarrationLine : ScriptableObject
{

    [SerializeField]
    private NarrationCharacter m_Speaker; //holds the speaker of the line

    [SerializeField]
    [Multiline]
    private string m_Text; //Holds the line of text being spoken

    [SerializeField]
    private Image m_CharacterImage; //Holds the image of the character during this dialogue

    [SerializeField]
    private UnityEvent m_CharacterEvent; //Holds events that are to be played during this dialogue


    public NarrationCharacter Speaker => m_Speaker; //Gets speaker's name
    public string Text => m_Text; //Gets the dialogue text

    public Image CharacterImage => m_CharacterImage; //A public access for the character image

    public UnityEvent CharacterEvent => m_CharacterEvent; //Gets the events associated with this dialogue
}
