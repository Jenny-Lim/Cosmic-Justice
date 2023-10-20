using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueTextBoxController : MonoBehaviour, DialogueNodeVisitor
{
    [SerializeField]
    private TextMeshProUGUI m_SpeakerText;
    [SerializeField]
    private DialogueText m_DialogueText;

    [SerializeField]
    private RectTransform m_ChoicesBoxTransform;
    [SerializeField]
    private UIDialogueChoiceController m_ChoiceControllerPrefab;

    [SerializeField]
    private DialogueChannel m_DialogueChannel;

    private bool m_ListenToInput = false;
    private DialogueNode m_NextNode = null;

    [SerializeField]
    private EventManager eventManager;

    private bool canGoNext;

    private void Awake()
    {
        m_DialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        m_DialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;
        eventManager.canDialogue += CanDialogueRequest;
        canGoNext = true;

        gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        m_DialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
        m_DialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
        eventManager.canDialogue -= CanDialogueRequest;
    }

    private void Update()
    {
        if (m_ListenToInput && Input.GetButtonDown("Submit") && canGoNext)
        {
            m_DialogueChannel.RaiseRequestDialogueNode(m_NextNode);
        }
    }

    private void CanDialogueRequest(bool can)
    {
        canGoNext = can;
    }

    //Reads from line at beginning of node starting
    private void OnDialogueNodeStart(DialogueNode node)
    {
        if (canGoNext)
        {
            gameObject.SetActive(true);

            m_DialogueText.startDialogue(node.DialogueLine.Text, node.DialogueLine.TextSpeed, node.DialogueLine.Font);
            m_SpeakerText.text = node.DialogueLine.Speaker.CharacterName;

            //If there are events then run them
            if (node.DialogueLine.events != 0)
            {
                EventManager.current.GetNode(node);
                //Save each event as a string in an array
                string[] eventsList = node.DialogueLine.events.ToString().Split(", ");

                foreach (string doEvent in eventsList)
                {
                    EventManager.current.Invoke(doEvent, 0);
                }
            }

            node.Accept(this);
        }
    }

    //Handles the ending of the dialogue
    private void OnDialogueNodeEnd(DialogueNode node)
    {
        m_NextNode = null;
        m_ListenToInput = false;
        m_SpeakerText.text = "";

        foreach (Transform child in m_ChoicesBoxTransform)
        {
            Destroy(child.gameObject);
        }

        gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);


        //If there is a minigame then run it
        if (node != null && node.DialogueLine.minigame != 0)
        {
            Debug.Log(node.DialogueLine.minigame.ToString());
            EventManager.current.Invoke(node.DialogueLine.minigame.ToString(), 0);
        }
    }

    public void Visit(BasicDialogueNode node)
    {
        m_ListenToInput = true;
        m_NextNode = node.NextNode;
    }

    public void Visit(ChoiceDialogueNode node)
    {
        m_ChoicesBoxTransform.gameObject.SetActive(true);

        foreach (DialogueChoice choice in node.Choices)
        {
            UIDialogueChoiceController newChoice = Instantiate(m_ChoiceControllerPrefab, m_ChoicesBoxTransform);
            newChoice.Choice = choice;
        }
    }
}