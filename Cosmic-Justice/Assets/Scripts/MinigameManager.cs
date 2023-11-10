using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidMinigame;

    [SerializeField]
    private GameObject dialMinigame;

    [SerializeField]
    private GameObject puzzleMinigame;


    // Start is called before the first frame update
    void Start()
    {
        //subscribe to the canvasShake event
        EventManager.current.asteroid += StartAsteroidMinigame;
        EventManager.current.endAsteroid += EndAsteroidMinigame;
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
        asteroidMinigame.SetActive(true);
    }

    private void EndAsteroidMinigame()
    {
        EventManager.current.CanDialogue(true);
        asteroidMinigame.SetActive(false);
    }
}
