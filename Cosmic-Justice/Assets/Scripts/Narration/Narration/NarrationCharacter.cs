using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

[System.Serializable]
public struct CharacterSprites
{
    public string name;
    public int FramesPerSecond;
    public Sprite[] sprite;
}

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

    [SerializeField]
    private AudioClip voice;

    [SerializeField]
    private bool left;

    public string CharacterName => m_CharacterName; //A public access for the character name

    public Sprite DialoguePanel => m_DialoguePanel; //Public access for the dialogue panel image

    public TMP_FontAsset Font => m_Font;

    public Color Color => m_Color;

    public AudioClip Voice => voice;

    public CharacterSprites[] sprites;

    public bool Left => left;
}
