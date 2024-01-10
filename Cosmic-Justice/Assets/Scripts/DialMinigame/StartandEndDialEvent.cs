using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartandEndDialEvent : MonoBehaviour // UNUSED
{
    private void Start()
    {
        //subscribe to the canvasShake event
        EventManager.current.dial += StartDialMinigame;
        EventManager.current.endDial += EndDialMinigame;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        //unsubscribe to the canvasShake event
        EventManager.current.dial -= StartDialMinigame;
        EventManager.current.endDial -= EndDialMinigame;
    }

    private void StartDialMinigame()
    {
        EventManager.current.CanDialogue(false);
        gameObject.SetActive(true);
    }

    private void EndDialMinigame()
    {
        EventManager.current.CanDialogue(true);
        gameObject.SetActive(false);
    }
}
