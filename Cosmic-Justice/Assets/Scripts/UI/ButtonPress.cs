using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    private Animator anim;

    private int numClicks;

    void Awake()
    {
        anim = GetComponent<Animator>();
        numClicks = 0;
    }

    public void OnButtonPress()
    {
        numClicks++;

        if (numClicks % 2 == 0)
            return;

        //Debug.Log("pressed");
        anim.SetTrigger("pressed");
    } // OnButtonPress

    public void DonePress()
    {
        anim.SetTrigger("donePress");
    }
}
