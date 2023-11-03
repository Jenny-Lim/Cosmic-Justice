using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Character")]
public class NarrationCharacter : ScriptableObject
{
    [SerializeField]
    private string m_CharacterName; //The name of the character talking

    [SerializeField]
    private Sprite m_DialoguePanel; //The panel image

    [SerializeField]
    private TMP_FontAsset m_Font;

    [SerializeField]
    private Color m_Color = Color.black;

    public string CharacterName => m_CharacterName; //A public access for the character name

    public Sprite DialoguePanel => m_DialoguePanel; //Public access for the dialogue panel image

    public TMP_FontAsset Font => m_Font;

    public Color Color => m_Color;
}
