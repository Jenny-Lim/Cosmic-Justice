using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class DialogueMinigameController : MonoBehaviour
{
    [SerializeField]
    private DialogueChannel m_DialogueChannel;

    public DialogueNode m_MinigameNextNode;
    public bool m_IsWinningPath;

    public DialogueMinigame path
    {
        set
        {
            m_MinigameNextNode = value.PathNode;
            m_IsWinningPath = value.isWinningPath;
        }
    }

    void Update() // most certainly a timing thing, is won being set after is done?
    {
        if (MinigameManager.current.isDone)
        {
            if (MinigameManager.current.isWon == m_IsWinningPath)
            {
                Debug.Log("winningpath: "+m_IsWinningPath);
                m_DialogueChannel.RaiseRequestDialogueNode(m_MinigameNextNode);
               
            }
            Destroy(gameObject);
        }
        
    }
}
