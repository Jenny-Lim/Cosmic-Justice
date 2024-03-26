using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static NarrationLine;

public class MinigameManager : MonoBehaviour
{

    public static MinigameManager current;
    public bool isWon, isDone;

    [SerializeField]
    private GameObject nextButton, nameTag;

    //[SerializeField]
    //private ScreenWipe screenWipe;

    [SerializeField]
    private GameObject animatedGOHolder;
    [SerializeField]
    private Transform verdictTransform;

    [SerializeField] private DialogueChannel channel;

    [SerializeField] private Dialogue[] caseStarts;

    //asteroidMinigame, dialMinigame, puzzleMinigame,

    //[SerializeField]
    //private GameObject verdictMinigame;

    [SerializeField]
    private CanvasRenderer dialogueText, characterName;
    [SerializeField]
    private Image dialogueBox;


    [SerializeField]
    private GameObject MinigameYesOrNo;

    private GameObject minigameToPlay;

    public bool WaitForInput;

    public bool SkipMinigame;

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        //subscribe to the canvasShake event
        EventManager.current.asteroid += StartMinigame;
        EventManager.current.endAsteroid += EndMinigame;
        EventManager.current.dial += StartMinigame;
        EventManager.current.endDial += EndMinigame;
        EventManager.current.puzzle += StartMinigame;
        EventManager.current.endPuzzle += EndMinigame;

        EventManager.current.nextCase += NextCase;

        EventManager.current.animationPlay += StartAnimation;
        EventManager.current.animationStop += EndAnimation;

        //EventManager.current.verdict += StartVerdictMinigame;
        //EventManager.current.endVerdict += EndVerdictMinigame;

        //isWon = false;
        //isDone = false;
    }

    private void OnDestroy()
    {
        //unsubscribe to the canvasShake event
        EventManager.current.asteroid -= StartMinigame;
        EventManager.current.endAsteroid -= EndMinigame;
        EventManager.current.dial -= StartMinigame;
        EventManager.current.endDial -= EndMinigame;
        EventManager.current.puzzle -= StartMinigame;
        EventManager.current.endPuzzle -= EndMinigame;

        EventManager.current.nextCase -= NextCase;

        EventManager.current.animationPlay -= StartAnimation;
        EventManager.current.animationStop -= EndAnimation;

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

    //private void StartAsteroidMinigame()
    //{
    //    hidePanel();
    //    EventManager.current.CanDialogue(false);
    //    //asteroidMinigame.SetActive(true);

    //    AudioManager.instance.Pause("Ambient_Track_A");
    //    AudioManager.instance.Play("MiniGame_Track_A");
    //}

    //private void EndAsteroidMinigame()
    //{
    //    showPanel();
    //    EventManager.current.CanDialogue(true);
    //    asteroidMinigame.SetActive(false);

    //    AudioManager.instance.UnPause("Ambient_Track_A");
    //    AudioManager.instance.Stop("MiniGame_Track_A");
    //}

    // HOW TO USE: attach minigame script onto minigame parent, control minigame functioning through its "playablility" bool

    IEnumerator StartMinigameAnim(GameObject minigame, string audioToPlay, string audioToPause)
    {
        DeskObject[] deskObjects = minigame.transform.GetComponentsInChildren<DeskObject>();
        List<DeskObject> objList = new List<DeskObject>();

        objList.AddRange(deskObjects);

        if (objList.Count>0)
        {
            AudioManager.instance.Play("DeskMovementA");
        }
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

        if (objList.Count>0)
        {
            AudioManager.instance.Play("DeskMovementA");
        }
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

    //private void StartDialMinigame()
    //{
    //    hidePanel();
    //    EventManager.current.CanDialogue(false);
    //    dialMinigame.SetActive(true); // on enable, animate them going up

    //    StartCoroutine(StartMinigameAnim(dialMinigame, "MiniGame_Track_A", "Ambient_Track_A"));
    //} // StartDialMinigame

    //private void EndDialMinigame()
    //{
    //    isDone = true;
    //    StartCoroutine(StopMinigameAnim(dialMinigame, "MiniGame_Track_A", "Ambient_Track_A"));
    //} // EndDialMinigame

    private void StartMinigame(GameObject minigame)
    {
        WaitForInput = true;

        minigameToPlay = null;

        hidePanel();
        EventManager.current.CanDialogue(false);
        minigame.SetActive(true); // on enable, animate them going up

        minigameToPlay = minigame;

        MinigameYesOrNo.SetActive(true);

        //StartCoroutine(StartMinigameAnim(minigame, "MiniGame_Track_A", "Ambient_Track_A"));
    } // StartMinigame


    public void YesMinigameButtonClicked()
    {
        SkipMinigame = false;
        StartCoroutine(StartMinigameAnim(minigameToPlay, "MiniGame_Track_A", "Ambient_Track_A"));
    }

    public void NoMinigameButtonClicked()
    {
        SkipMinigame = true;


        DeskObject[] deskObjects = minigameToPlay.transform.GetComponentsInChildren<DeskObject>();
        List<DeskObject> objList = new List<DeskObject>();

        objList.AddRange(deskObjects);

        foreach (DeskObject obj in objList.ToList())
        {
            //obj.BringDown();
            objList.Remove(obj);
        }

        minigameToPlay.SetActive(false);
        showPanel();
        EventManager.current.CanDialogue(true);
    }

    private void EndMinigame(GameObject minigame)
    {
        //isDone = true;
        StartCoroutine(StopMinigameAnim(minigame, "MiniGame_Track_A", "Ambient_Track_A"));
    } // EndMinigame

    private void StartAnimation(GameObject GO)
    {
        Debug.Log("hi -- start anim");
        Instantiate(GO, animatedGOHolder.transform);
    } // StartAnimation

    private void EndAnimation()
    {
        foreach (Transform child in animatedGOHolder.transform)
        {
            Destroy(child.gameObject);
        }
    } // EndAnimation

    private void NextCase()
    {
        //hidePanel();
        StartCoroutine("NextCaseCORO");
    }

    private IEnumerator NextCaseCORO() // deed it
    {
        EventManager.current.CanDialogue(false);
        //hidePanel();
        yield return new WaitForSeconds(1f);

        // screenwipe
        //ScreenWipe.instance.SetFillMethod();

        ScreenWipe.instance.ToggleWipe(true);
        while (!ScreenWipe.instance.isDone)
            yield return null;

        foreach(Transform child in verdictTransform) // clear verdict panel
        {
            Destroy(child.gameObject);
        }

        ScreenWipe.instance.ToggleWipe(false);

        //EventManager.current.currCase++;
        CaseSelector.instance.setCase++;
        SplashScreenController.Instance.ShowCase(CaseSelector.instance.setCase);
        yield return new WaitUntil(() => SplashScreenController.Instance.pressed);
        SplashScreenController.Instance.pressed = false; // reset

        EventManager.current.CanDialogue(true);
        //channel.RaiseRequestDialogueNode(caseStarts[EventManager.current.currCase-1].FirstNode);
        channel.RaiseRequestDialogueNode(caseStarts[CaseSelector.instance.setCase].FirstNode);

        yield return new WaitForSeconds(1f);
        //showPanel();

        //ScreenWipe.instance.ToggleWipe(false);
        while (!ScreenWipe.instance.isDone)
            yield return null;
    }

    public void ResetVerdict()
    {
        foreach (Transform child in verdictTransform) // clear verdict panel
        {
            Destroy(child.gameObject);
        }
    }

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
