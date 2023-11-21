using System;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

[Serializable]
public class DialogueMinigame
{
    [SerializeField]
    private DialogueNode m_PathNode;

    public DialogueNode PathNode => m_PathNode;

    [SerializeField]
    public bool isWinningPath;
}

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Node/Minigame")]
public class MinigameDialogueNode : DialogueNode
{
    [SerializeField]
    private DialogueMinigame[] m_Paths;
    public DialogueMinigame[] Paths => m_Paths;

    public override bool CanBeFollowedByNode(DialogueNode node)
    {
        return m_Paths.Any(x => x.PathNode == node);
    }

    public override void Accept(DialogueNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}