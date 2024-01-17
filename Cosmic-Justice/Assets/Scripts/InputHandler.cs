using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    private bool case1;
    private bool case2;
    private bool case3;

    [SerializeField] private DialogueChannel channel;

    [SerializeField] private UIDialogueTextBoxController currentNode;

    [SerializeField] private Dialogue case1Start;

    [SerializeField] private Dialogue case1ChoiceDebug;


    private void Awake()
    {
        case1 = false;
        case2 = false;
        case3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!case1)
                case1 = true;
            else
                case1 = false;
        }

        if (case1)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                channel.RaiseDialogueNodeEnd(currentNode.currNode);
                channel.RaiseDialogueEnd(case1Start);
                channel.RaiseRequestDialogueNode(case1ChoiceDebug.FirstNode);
            }

            
        }
    }
}
