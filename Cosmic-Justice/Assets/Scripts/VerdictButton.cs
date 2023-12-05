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

    IEnumerator EndingVerdict()
    {
        foreach (Transform child in verdictPanel.transform)
        {
            Destroy(child.gameObject);
        }
        yield return new WaitForSeconds(10f);
        Debug.Log("deleted children");
        if (dialoguePanel) // i hate you so much
        {
            dialoguePanel.SetActive(true);
        }
    }
    public void EndVerdict() // animation event
    {
        //foreach (Transform child in verdictPanel.transform)
        //{
        //    Destroy(child.gameObject);
        //}

        //if (dialoguePanel) // i hate you so much
        //    {
        //        dialoguePanel.SetActive(true);
        //    }

        Debug.Log("in end verdict");

        StartCoroutine("EndingVerdict");

    } // EndVerdict
}
