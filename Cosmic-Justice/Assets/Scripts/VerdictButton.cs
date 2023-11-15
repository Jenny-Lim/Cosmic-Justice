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

    //private LayoutElement layoutElement;

    // Start is called before the first frame update
    void Awake()
    {
        //layoutElement = gameObject.GetComponent<LayoutElement>();
        dialoguePanel = GameObject.FindWithTag("DialoguePanel");
        b = GetComponent<Button>();
        anim = GetComponent<Animator>();

        // animate it coming up
        //dialoguePanel.SetActive(false);
        //anim.Play("ButtonComeUp");
    } // Start

    void OnEnable()
    {
        Debug.Log("hi");
        verdictPanel = GameObject.FindWithTag("VerdictPanel");
        if (dialoguePanel) { // im aware this isnt amazing
            dialoguePanel.SetActive(false);
        }
        //layoutElement.ignoreLayout = true;
        anim.Play("ButtonComeUp");
    }

    public void OnButtonPress()
    {
        //layoutElement.ignoreLayout = true;
        anim.SetTrigger("pressed");
        b.interactable = false;
        verdictPanel.SetActive(false);
        if (dialoguePanel)
        {
            dialoguePanel.SetActive(true);
        }
    } // OnButtonPress

    public void DoneComeUp() // animation event
    {
        //layoutElement.ignoreLayout = false;
        b.interactable = true;
        Debug.Log("done come up!");
    } // DoneComeUp

    public void EndVerdict() // animation event
    {
        //EventManager.current.EndVerdict();
        //dialoguePanel.SetActive(true);
        //this.gameObject.SetActive(false);
        //verdictPanel.SetActive(false); // timing is off
    } // EndVerdict
}
