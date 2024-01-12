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
    private RectTransform verdictTransform;
    [SerializeField]
    private UIDialogueChoiceController_Verdict verdictPrefab;

    [SerializeField]
    private DialogueMinigameController MinigameControllerPrefab;

    [SerializeField]
    private DialogueChannel m_DialogueChannel;

    private bool m_ListenToInput = false;
    private DialogueNode m_NextNode = null;

    [SerializeField]
    private EventManager eventManager;

    [SerializeField]
    private Image dialoguePanel;

    private bool canGoNext;

    //Handles the clicking of the button
    private bool canClickToNext;
    private bool click;

    private void Awake()
    {
        m_DialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        m_DialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;
        eventManager.canDialogue += CanDialogueRequest;
        canGoNext = true;
        canClickToNext = true;
        click = false;

        gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);
    }

    private void Start()
    {
        EventManager.current.dialogueClick += CanClickNext;
        EventManager.current.click += Click;
    }

    private void OnDestroy()
    {
        m_DialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
        m_DialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
        eventManager.canDialogue -= CanDialogueRequest;
        EventManager.current.dialogueClick -= CanClickNext;
        EventManager.current.click -= Click;
    }

    private void Update()
    {
        if (m_ListenToInput && click && canClickToNext && canGoNext)
        {
            m_DialogueChannel.RaiseRequestDialogueNode(m_NextNode);
        }
        click = false;
    }

    private void CanDialogueRequest(bool can)
    {
        canGoNext = can;
    }

    private void Click()
    {
        click = true;
    }

    private void CanClickNext(bool can)
    {
        canClickToNext = can;
        click = false;
    }

    //Reads from line at beginning of node starting
    private void OnDialogueNodeStart(DialogueNode node)
    {
        if (canGoNext)
        {
            gameObject.SetActive(true);

            //Start dialogue with function and give it the line, speed of dialogue, font, text size, and text color
            m_DialogueText.startDialogue(node.DialogueLine.Text, node.DialogueLine.TextSpeed, node.DialogueLine.Speaker.Font, node.DialogueLine.FontSize, node.DialogueLine.Speaker.Color, node.DialogueLine.Speaker.Voice);
            m_SpeakerText.color = node.DialogueLine.Speaker.Color;
            m_SpeakerText.text = node.DialogueLine.Speaker.CharacterName;

            EventManager.current.GetNode(node);

            EventManager.current.Invoke("CharacterAnimation", 0);

            //If there are events then run them
            if (node.DialogueLine.events != 0)
            {
                //Save each event as a string in an array
                string[] eventsList = node.DialogueLine.events.ToString().Split(", ");

                foreach (string doEvent in eventsList)
                {
                    EventManager.current.Invoke(doEvent, 0);
                }
            }

            if (node.DialogueLine.Speaker.DialoguePanel != null)
                dialoguePanel.sprite = node.DialogueLine.Speaker.DialoguePanel;

            if (node.DialogueLine.Speaker.Font != null)
                m_SpeakerText.font = node.DialogueLine.Speaker.Font;

            if (node.DialogueLine.character1 != null || node.DialogueLine.character2 != null)
                EventManager.current.Invoke("SetCharacters", 0);

            if (!string.IsNullOrEmpty(node.DialogueLine.CharacterSprite1))
                EventManager.current.Invoke("Character1SpriteChange", 0);

            if (!string.IsNullOrEmpty(node.DialogueLine.CharacterSprite2))
                EventManager.current.Invoke("Character2SpriteChange", 0);

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
            if (node.DialogueLine.minigame.ToString() != "None")
            {
                Debug.Log(node.DialogueLine.minigame.ToString());
                EventManager.current.Invoke(node.DialogueLine.minigame.ToString(), 0);
            }
        }
    }

    public void Visit(BasicDialogueNode node)
    {
        m_ListenToInput = true;
        m_NextNode = node.NextNode;
    }

    public void Visit(ChoiceDialogueNode node)
    {
        if (!node.isVerdict) {
            m_ChoicesBoxTransform.gameObject.SetActive(true);

            foreach (DialogueChoice choice in node.Choices)
            {

                UIDialogueChoiceController newChoice = Instantiate(m_ChoiceControllerPrefab, m_ChoicesBoxTransform);
                newChoice.Choice = choice;
            }
        }
        else
        {
            verdictTransform.gameObject.SetActive(true);
            int i = 0;
            foreach (DialogueChoice choice in node.Choices)
            {
                //verdictTransform.anchoredPosition += new Vector2(verdictTransform.anchoredPosition.x * i, 0);
                UIDialogueChoiceController_Verdict newChoice = Instantiate(verdictPrefab, verdictTransform); // have transform be -half the width of the button on start
                RectTransform rt = newChoice.GetComponent<Button>().GetComponent<RectTransform>();
                newChoice.transform.localPosition += new Vector3(rt.sizeDelta.x * i, 0 ,0);
                newChoice.Choice = choice;
                i++;
            }
        }
    }

    public void Visit(MinigameDialogueNode node)
    {
        foreach (DialogueMinigame m in node.Paths)
        {
            DialogueMinigameController newController = Instantiate(MinigameControllerPrefab);
            newController.path = m;
        }
    }
}