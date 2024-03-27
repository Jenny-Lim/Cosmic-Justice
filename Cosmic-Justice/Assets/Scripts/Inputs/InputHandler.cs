using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{

    private InputController input;

    private bool case1;
    private bool case2;
    private bool case3;

    [SerializeField] private DialogueChannel channel;

    [SerializeField] private Image leftCharacter;
    [SerializeField] private Image rightCharacter;

    [Header("--------Case 1 Debug Dialogues--------")]
    [SerializeField] private Dialogue case1StartDebug;
    [SerializeField] private Dialogue case1ChoiceDebug;
    [SerializeField] private Dialogue case1VerdictDebug;
    [SerializeField] private Dialogue case1MinigameDebug;
    [SerializeField] private Dialogue case1PostMinigameDebug;

    [Header("--------Case 2 Debug Dialogues--------")]
    [SerializeField] private Dialogue case2StartDebug;
    [SerializeField] private Dialogue case2ChoiceDebug;
    [SerializeField] private Dialogue case2VerdictDebug;
    [SerializeField] private Dialogue case2MinigameDebug;
    [SerializeField] private Dialogue case2PostMinigameDebug;

    [Header("--------Case 3 Debug Dialogues--------")]
    [SerializeField] private Dialogue case3StartDebug;
    [SerializeField] private Dialogue case3ChoiceDebug;
    [SerializeField] private Dialogue case3VerdictDebug;
    [SerializeField] private Dialogue case3MinigameDebug;
    [SerializeField] private Dialogue case3PostMinigameDebug;




    private void Awake()
    {
        case1 = false;
        case2 = false;
        case3 = false;

        input = InputController.instance;
    }

    // Update is called once per frame
    void Update() // JENNY TODO: also reset verdict buttons
    {
        if(input.IsInteract)
        {
            EventManager.current.MouseClick();
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!case1)
            {
                case1 = true;
                case2 = false;
                case3 = false;
            }

        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!case2)
            {
                case2 = true;
                case1 = false;
                case3 = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!case3)
            {
                case3 = true;
                case2 = false;
                case1 = false;
            }
        }



        if (case1)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case1StartDebug.FirstNode);
                MinigameManager.current.ResetVerdict();
                case1 = false; 
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case1ChoiceDebug.FirstNode);
                MinigameManager.current.ResetVerdict();
                ShowCharacters();
                case1 = false; 
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case1VerdictDebug.FirstNode);
                //MinigameManager.current.ResetVerdict();
                ShowCharacters();
                case1 = false; 
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case1MinigameDebug.FirstNode);
                MinigameManager.current.ResetVerdict();
                ShowCharacters();
                case1 = false; 
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case1PostMinigameDebug.FirstNode);
                MinigameManager.current.ResetVerdict();
                ShowCharacters();
                case1 = false; 
            }
        } // case1
        else if (case2)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case2StartDebug.FirstNode);
                MinigameManager.current.ResetVerdict();
                case2 = false; 
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case2ChoiceDebug.FirstNode);
                MinigameManager.current.ResetVerdict();
                ShowCharacters();
                case2 = false; 
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case2VerdictDebug.FirstNode);
                //MinigameManager.current.ResetVerdict();
                ShowCharacters();
                case2 = false; 
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case2MinigameDebug.FirstNode);
                MinigameManager.current.ResetVerdict();
                ShowCharacters();
                case2 = false; 
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case2PostMinigameDebug.FirstNode);
                MinigameManager.current.ResetVerdict();
                ShowCharacters();
                case2 = false; 
            }
        } // case2
        else if (case3)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case3StartDebug.FirstNode);
                MinigameManager.current.ResetVerdict();
                case3 = false; 
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case3ChoiceDebug.FirstNode);
                MinigameManager.current.ResetVerdict();
                ShowCharacters();
                case3 = false; 
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case3VerdictDebug.FirstNode);
                //MinigameManager.current.ResetVerdict(); // maybe just hide it and make sure it empties properly -- thankfully it doesnt matter if i dont reset them here
                ShowCharacters();
                case3 = false; 
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case3MinigameDebug.FirstNode);
                MinigameManager.current.ResetVerdict();
                ShowCharacters();
                case3 = false; 
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                EventManager.current.Debug();
                EventManager.current.CanDialogue(true);
                EventManager.current.EndOpenMinigame();
                channel.RaiseRequestDialogueNode(case3PostMinigameDebug.FirstNode);
                MinigameManager.current.ResetVerdict();
                ShowCharacters();
                case3 = false; 
            }
        } // case3
    }

    private void ShowCharacters()
    {
        leftCharacter.color = new Color(leftCharacter.color.r, leftCharacter.color.g, leftCharacter.color.b, 1);
        rightCharacter.color = new Color(rightCharacter.color.r, rightCharacter.color.g, rightCharacter.color.b, 1);
    }
}
