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

    // Start is called before the first frame update
    void Awake()
    {
        dialoguePanel = GameObject.FindWithTag("DialoguePanel");
        b = GetComponent<Button>();
        anim = GetComponent<Animator>();
    } // Start

    void OnEnable()
    {
        Debug.Log("hi");
        verdictPanel = GameObject.FindWithTag("VerdictPanel");
        if (dialoguePanel) { // im aware this isnt amazing
            dialoguePanel.SetActive(false);
        }
        //anim.Play("ButtonComeUp");
        StartCoroutine("ButtonComeUp");
    }

    IEnumerator ButtonComeUp()
    {
        anim.Play("ButtonComeUp");
        yield return null;
    }

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
    }

    IEnumerator HideChildren() // move this outside -- onto panel
    {
        Debug.Log("InHideChildren");
        foreach (Transform child in verdictPanel.transform)
        {
            child.gameObject.GetComponent<CanvasRenderer>().cull = true;
            child.GetChild(0).gameObject.GetComponent<CanvasRenderer>().cull = true;
        }
        yield return new WaitForSeconds(10f);
    }

    public void OnButtonPress()
    {
        Debug.Log("pressed");
        anim.SetTrigger("pressed");
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

        if (dialoguePanel) // i hate you so much
        {
            dialoguePanel.SetActive(true);
        }

        Debug.Log("in end verdict");
    } // EndVerdict
}
