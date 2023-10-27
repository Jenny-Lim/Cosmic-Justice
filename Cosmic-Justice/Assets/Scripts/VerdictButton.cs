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
        anim.SetBool("isPressed", true); // not working atm -- will fix very soon
        //anim.SetBool("isPressed", false);
    }

    public void DoneComeUp()
    {
        b.interactable = true; // object ref error
        Debug.Log("done come up!");
    }
}