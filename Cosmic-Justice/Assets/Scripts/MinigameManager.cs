using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject asteroidMinigame, dialMinigame, puzzleMinigame;

    //[SerializeField]
    //private GameObject verdictMinigame;

    [SerializeField]
    private CanvasRenderer dialogueText, characterName;
    [SerializeField]
    private Image dialogueBox;
    

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
        Debug.Log("hi");
        dialogueBox.enabled = false;
        dialogueText.cull = true;
        characterName.cull = true;
    }

    void showPanel()
    {
        dialogueBox.enabled = true;
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
        dialMinigame.SetActive(false);
        EventManager.current.CanDialogue(true);

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
