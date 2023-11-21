using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class DialogueMinigameController : MonoBehaviour
{
    [SerializeField]
    private DialogueChannel m_DialogueChannel;

    private DialogueNode m_MinigameNextNode;
    private bool m_IsWinningPath;

    public DialogueMinigame path
    {
        set
        {
            m_MinigameNextNode = value.PathNode;
            m_IsWinningPath = value.isWinningPath;
        }
    }

    void Update()
    {
        if (MinigameManager.current.isDone)
        {
            if (MinigameManager.current.isWon == m_IsWinningPath)
            {
                m_DialogueChannel.RaiseRequestDialogueNode(m_MinigameNextNode);
               
            }
            Destroy(gameObject);
        }
        
    }
}
