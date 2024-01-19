using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{

    private bool case1;
    private bool case2;
    private bool case3;

    [SerializeField] private DialogueChannel channel;

    [SerializeField] private Image leftCharacter;
    [SerializeField] private Image rightCharacter;

    [Header("--------Case 1 Debug Dialogues--------")]
    [SerializeField] private Dialogue case1ChoiceDebug;
    [SerializeField] private Dialogue case1VerdictDebug;
    [SerializeField] private Dialogue case1MinigameDebug;



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
        }

        if (case1)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                EventManager.current.Debug();
                channel.RaiseRequestDialogueNode(case1ChoiceDebug.FirstNode);
                ShowCharacters();
                case1 = false;
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                EventManager.current.Debug();
                channel.RaiseRequestDialogueNode(case1VerdictDebug.FirstNode);
                ShowCharacters();
                case1 = false;
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                EventManager.current.Debug();
                channel.RaiseRequestDialogueNode(case1MinigameDebug.FirstNode);
                ShowCharacters();
                case1 = false;
            }


        }
    }

    private void ShowCharacters()
    {
        leftCharacter.color = new Color(leftCharacter.color.r, leftCharacter.color.g, leftCharacter.color.b, 1);
        rightCharacter.color = new Color(rightCharacter.color.r, rightCharacter.color.g, rightCharacter.color.b, 1);
    }
}
