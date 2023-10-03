using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartandEndAsteroidEvent : MonoBehaviour
{

    private void Start()
    {
        //subscribe to the canvasShake event
        EventManager.current.asteroid += StartAsteroidMinigame;
        EventManager.current.endAsteroid += EndAsteroidMinigame;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        //unsubscribe to the canvasShake event
        EventManager.current.asteroid -= StartAsteroidMinigame;
        EventManager.current.endAsteroid -= EndAsteroidMinigame;
    }

    private void StartAsteroidMinigame()
    {
        EventManager.current.CanDialogue(false);
        gameObject.SetActive(true);
    }

    private void EndAsteroidMinigame()
    {
        EventManager.current.CanDialogue(true);
        gameObject.SetActive(false);
    }
}
