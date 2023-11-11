using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerdictButton : MonoBehaviour
{
    private Animator anim;
    private Button b;

    private GameObject dialoguePanel;

    // Start is called before the first frame update
    void Awake()
    {
        dialoguePanel = GameObject.FindWithTag("DialoguePanel");
        b = GetComponent<Button>();
        anim = GetComponent<Animator>();

        // animate it coming up
        dialoguePanel.SetActive(false);
        anim.Play("ButtonComeUp");
    } // Start

    public void OnButtonPress()
    {
        anim.SetTrigger("pressed");
    } // OnButtonPress

    public void DoneComeUp() // animation event
    {
        b.interactable = true;
        Debug.Log("done come up!");
    } // DoneComeUp

    public void EndVerdict() // animation event
    {
        //EventManager.current.EndVerdict();
        dialoguePanel.SetActive(true);
    } // EndVerdict
}
