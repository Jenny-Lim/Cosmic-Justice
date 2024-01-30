using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{

    public static MinigameManager current;
    public bool isWon, isDone;

    [SerializeField]
    private GameObject asteroidMinigame, dialMinigame, puzzleMinigame, nextButton, nameTag;

    //[SerializeField]
    //private GameObject verdictMinigame;

    [SerializeField]
    private CanvasRenderer dialogueText, characterName;
    [SerializeField]
    private Image dialogueBox;

    private void Awake()
    {
        current = this;
    }

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

        //isWon = false;
        //isDone = false;
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
        
        dialogueBox.enabled = false;
        dialogueText.cull = true;
        nextButton.SetActive(false);
        characterName.cull = true;
        nameTag.SetActive(false);
    }

    void showPanel()
    {
        dialogueBox.enabled = true;
        nextButton.SetActive(true);
        dialogueText.cull = false;
        characterName.cull = false;
        nameTag.SetActive(true);
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

    // could possibly make these cleaner -- HOW TO USE: attach minigame script onto minigame parent, control minigame functioning through its "playablility" bool

    IEnumerator StartMinigameAnim(GameObject minigame, string audioToPlay, string audioToPause)
    {
        DeskObject[] deskObjects = minigame.transform.GetComponentsInChildren<DeskObject>();
        List<DeskObject> objList = new List<DeskObject>();

        objList.AddRange(deskObjects);

        foreach (DeskObject obj in objList.ToList())
        {
            yield return new WaitUntil(() => obj.broughtUp);
            objList.Remove(obj);
        }

        yield return new WaitUntil(() => objList.Count <= 0);
        Minigame m = minigame.GetComponent<Minigame>();
        m.SetPlayability(true);
        AudioManager.instance.Pause(audioToPause);
        AudioManager.instance.Play(audioToPlay);
        yield return null;
    } // StartMinigameAnim

    IEnumerator StopMinigameAnim(GameObject minigame, string audioToStop, string audioToUnPause)
    {
        AudioManager.instance.UnPause(audioToUnPause);
        AudioManager.instance.Stop(audioToStop);

        Minigame m = minigame.GetComponent<Minigame>();
        m.SetPlayability(false);

        DeskObject[] deskObjects = minigame.transform.GetComponentsInChildren<DeskObject>();
        List<DeskObject> objList = new List<DeskObject>();

        objList.AddRange(deskObjects);

        foreach (DeskObject obj in objList)
        {
            obj.BringDown();
        }

        foreach (DeskObject obj in objList.ToList())
        {
            //obj.BringDown();
            yield return new WaitUntil(() => obj.broughtDown);
            objList.Remove(obj);
        }

        yield return new WaitUntil(() => objList.Count <= 0);
        minigame.SetActive(false);
        showPanel();
        EventManager.current.CanDialogue(true);

        yield return null;
    } // StopMinigameAnim

    private void StartDialMinigame()
    {
        hidePanel();
        EventManager.current.CanDialogue(false);
        dialMinigame.SetActive(true); // on enable, animate them going up

        StartCoroutine(StartMinigameAnim(dialMinigame, "MiniGame_Track_A", "Ambient_Track_A"));
    } // StartDialMinigame

    private void EndDialMinigame()
    {
        isDone = true;
        StartCoroutine(StopMinigameAnim(dialMinigame, "MiniGame_Track_A", "Ambient_Track_A"));
    } // EndDialMinigame


    // UNUSED

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