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
        //anim.Play("ButtonComeUp");
        StartCoroutine("ButtonComeUp");
    }

    IEnumerator ButtonComeUp()
    {
        anim.Play("ButtonComeUp");
        yield return null;
    }

    IEnumerator DeleteChildren()
    {
        foreach (Transform child in verdictPanel.transform)
        {
            Destroy(child.gameObject);
        }
        yield return null;
    }

    IEnumerator DisableChildren()
    {
        foreach (Transform child in verdictPanel.transform)
        {
            Button b = child.gameObject.GetComponent<Button>();
            if (b)
            {
                b.interactable = false;
            }
        }
        yield return null;
    }

    public void OnButtonPress()
    {
        //layoutElement.ignoreLayout = true;
        anim.SetTrigger("pressed");

        //StartCoroutine("ButtonGoDown");

        StartCoroutine("DisableChildren");
        //b.interactable = false;
        //verdictPanel.SetActive(false);
        //if (dialoguePanel)
        //{
        //    dialoguePanel.SetActive(true);
        //}
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

        //b.interactable = false;
        //verdictPanel.SetActive(false);
        StartCoroutine("DeleteChildren");

            if (dialoguePanel) // i hate you so much -- probably want to play with the animator
            {
                dialoguePanel.SetActive(true);
            }

    } // EndVerdict
}
