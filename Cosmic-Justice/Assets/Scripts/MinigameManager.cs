using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject asteroidMinigame, dialMinigame, puzzleMinigame;

    //[SerializeField]
    //private GameObject verdictMinigame;

    [SerializeField]
    private CanvasRenderer dialogueBox, dialogueText, characterName;
    

    // Start is called before the first frame update
    void Start()
    {

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

    void hidePanel()
    {
        dialogueBox.cull = false;
        dialogueText.cull = false;
        characterName.cull = false;
    }

    void showPanel()
    {
        dialogueBox.cull = false;
        dialogueText.cull = false;
        characterName.cull = false;
    }

    private void StartAsteroidMinigame()
    {
        hidePanel();
        EventManager.current.CanDialogue(false);
        asteroidMinigame.SetActive(true);

        AudioManager.instance.Pause("Ambient_Track_A");
        AudioManager.instance.Play("MiniGame_Track_A");
    }

    private void EndAsteroidMinigame()
    {
        showPanel();
        EventManager.current.CanDialogue(true);
        asteroidMinigame.SetActive(false);

        AudioManager.instance.UnPause("Ambient_Track_A");
        AudioManager.instance.Stop("MiniGame_Track_A");
    }

    private void StartDialMinigame()
    {
        hidePanel();
        EventManager.current.CanDialogue(false);
        dialMinigame.SetActive(true);

        AudioManager.instance.Pause("Ambient_Track_A");
        AudioManager.instance.Play("MiniGame_Track_A");
    }

    private void EndDialMinigame()
    {
        showPanel();
        EventManager.current.CanDialogue(true);
        dialMinigame.SetActive(false);

        AudioManager.instance.UnPause("Ambient_Track_A");
        AudioManager.instance.Stop("MiniGame_Track_A");
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
