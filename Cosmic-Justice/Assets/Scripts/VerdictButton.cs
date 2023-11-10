using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerdictButton : MonoBehaviour
{
    private Animator anim;
    private Button b;

    // Start is called before the first frame update
    void Start()
    {
        b = GetComponent<Button>();
        anim = GetComponent<Animator>();

        // animate it coming up
        anim.Play("ButtonComeUp");
    }

    public void OnButtonPress() // some animation on press / function / text -- inheritance ??? switches ??
    {
        anim.SetTrigger("pressed");
        //EventManager.current.EndAsteroid();
    }

    public void DoneComeUp() // animation event
    {
        b.interactable = true;
        Debug.Log("done come up!");
    }

    public void EndVerdict()
    {
        EventManager.current.EndAsteroid();
        EventManager.current.CanDialogue(true);
    }
}
