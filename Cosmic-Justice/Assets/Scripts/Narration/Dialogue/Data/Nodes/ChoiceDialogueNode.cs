using System;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

[Serializable]
public class DialogueChoice
{
    [SerializeField]
    private string m_ChoicePreview;
    [SerializeField]
    private DialogueNode m_ChoiceNode;
    [SerializeField]
    private Sprite m_ButtonSprite;
    [SerializeField]
    private TMP_FontAsset m_Font;
    [SerializeField]
    private Color m_FontColor = Color.black;

    public string ChoicePreview => m_ChoicePreview;
    public DialogueNode ChoiceNode => m_ChoiceNode;

    public Sprite ButtonSprite => m_ButtonSprite;

    public TMP_FontAsset Font => m_Font;

    public Color FontColor => m_FontColor;
}


[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Node/Choice")]
public class ChoiceDialogueNode : DialogueNode
{
    public bool isVerdict = false;

    [SerializeField]
    private DialogueChoice[] m_Choices;
    public DialogueChoice[] Choices => m_Choices;

    

    public override bool CanBeFollowedByNode(DialogueNode node)
    {
        return m_Choices.Any(x => x.ChoiceNode == node);
    }

    public override void Accept(DialogueNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}