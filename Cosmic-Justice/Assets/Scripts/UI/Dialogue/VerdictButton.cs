using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerdictButton : MonoBehaviour
{
    private Animator anim;
    private Button b;

    private GameObject dialoguePanel;
    private GameObject verdictPanel;

    [SerializeField] private UIDialogueChoiceController_Verdict verdictController;

    void Awake()
    {
        dialoguePanel = GameObject.FindWithTag("DialoguePanel");
        b = GetComponent<Button>();
        anim = GetComponent<Animator>();
    } // Awake

    void OnEnable()
    {
        Debug.Log("hi");
        verdictPanel = GameObject.FindWithTag("VerdictPanel");
        if (dialoguePanel) {
            dialoguePanel.SetActive(false);
        }
        StartCoroutine("ButtonComeUp");
    } // OnEnable

    IEnumerator ButtonComeUp()
    {
        anim.Play("ButtonComeUp");
        yield return null;
    } // ButtonComeUp

    void EnORDisableChildren(bool value)
    {
        foreach (Transform child in verdictPanel.transform)
        {
            Button b = child.gameObject.GetComponent<Button>();
            if (b)
            {
                b.interactable = value;
            }
        }
    } // EnORDisableChildren

    IEnumerator HideChildren() // move this outside -- onto panel
    {
        Debug.Log("InHideChildren");
        foreach (Transform child in verdictPanel.transform)
        {
            child.gameObject.GetComponent<CanvasRenderer>().cull = true;
            child.GetChild(0).gameObject.GetComponent<CanvasRenderer>().cull = true;
        }
        yield return new WaitForSeconds(10f);
    } // HideChildren

    public void OnButtonPress()
    {
        Debug.Log("pressed");
        anim.SetTrigger("pressed");
        AudioManager.instance.Play("Gavel");
        EnORDisableChildren(false);
    } // OnButtonPress

    public void DoneComeUp() // animation event
    {
        EnORDisableChildren(true);
        Debug.Log("done come up!");
    } // DoneComeUp

    public void EndVerdict() // animation event
    {
        StartCoroutine("HideChildren"); // hide them first, destroy later in panel controller

        verdictController.GoToNext();

        Debug.Log("in end verdict");
    } // EndVerdict
}
