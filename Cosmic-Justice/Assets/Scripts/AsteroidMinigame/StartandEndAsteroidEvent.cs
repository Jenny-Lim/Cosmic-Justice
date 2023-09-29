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
        gameObject.SetActive (true);
    }

    private void EndAsteroidMinigame()
    {
        gameObject.SetActive(false);
    }
}
