using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    [SerializeField]
    private DialogueNode m_FirstNode; //Holds the first node to go to

    public DialogueNode FirstNode => m_FirstNode; //Accesses the first node to go to
}
