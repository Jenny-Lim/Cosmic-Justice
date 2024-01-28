using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnButtonPress()
    {
        //Debug.Log("pressed");
        anim.SetTrigger("pressed");
    } // OnButtonPress

    public void DonePress()
    {
        anim.SetTrigger("donePress");
    }
}
