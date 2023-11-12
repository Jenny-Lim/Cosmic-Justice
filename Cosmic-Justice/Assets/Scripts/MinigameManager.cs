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

    //[SerializeField]
    //private GameObject verdictMinigame;

    private AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        if(audioManager == null) audioManager = FindObjectOfType<AudioManager>();

        //subscribe to the canvasShake event
        EventManager.current.asteroid += StartAsteroidMinigame;
        EventManager.current.endAsteroid += EndAsteroidMinigame;
        EventManager.current.dial += StartDialMinigame;
        EventManager.current.endDial += EndDialMinigame;
        //EventManager.current.verdict += StartVerdictMinigame;
        //EventManager.current.endVerdict += EndVerdictMinigame;
    }

    private void OnDestroy()
    {
        //unsubscribe to the canvasShake event
        EventManager.current.asteroid -= StartAsteroidMinigame;
        EventManager.current.endAsteroid -= EndAsteroidMinigame;
        EventManager.current.dial -= StartDialMinigame;
        EventManager.current.endDial -= EndDialMinigame;
        //EventManager.current.verdict -= StartVerdictMinigame;
        //EventManager.current.endVerdict -= EndVerdictMinigame;
    }

    private void StartAsteroidMinigame()
    {
        EventManager.current.CanDialogue(false);
        asteroidMinigame.SetActive(true);

        audioManager.Play("MiniGame_Track_A");
    }

    private void EndAsteroidMinigame()
    {
        EventManager.current.CanDialogue(true);
        asteroidMinigame.SetActive(false);

        audioManager.Play("Ambient_Track_A");
    }

    private void StartDialMinigame()
    {
        EventManager.current.CanDialogue(false);
        dialMinigame.SetActive(true);

        audioManager.Play("MiniGame_Track_A");
    }

    private void EndDialMinigame()
    {
        EventManager.current.CanDialogue(true);
        dialMinigame.SetActive(false);

        audioManager.Play("Ambient_Track_A");
    }
    
    //private void StartVerdictMinigame()
    //{
    //    EventManager.current.CanDialogue(false);
    //    verdictMinigame.SetActive(true);
    //}

    //private void EndVerdictMinigame()
    //{
    //    EventManager.current.CanDialogue(true);
    //    verdictMinigame.SetActive(false);
    //}
}
