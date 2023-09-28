using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAsteroidEvent : MonoBehaviour
{

    private void Start()
    {
        //subscribe to the canvasShake event
        EventManager.current.asteroid += StartAsteroidMinigame;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        //unsubscribe to the canvasShake event
        EventManager.current.asteroid -= StartAsteroidMinigame;
    }

    private void StartAsteroidMinigame()
    {
        gameObject.SetActive (true);
    }
}
