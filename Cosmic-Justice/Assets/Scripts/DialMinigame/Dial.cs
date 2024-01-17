using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dial : MonoBehaviour // TIMER INACTIVE RN
{
    // objects
    [SerializeField] GameObject needle;
    [SerializeField] TMP_Text statusText;
    [SerializeField] Button button;
    [SerializeField] public Timer timer;
    [SerializeField] public TMP_Text timerText;
    [SerializeField] public Slider health;
    [SerializeField] GameObject safeArea;
    [SerializeField] Minigame parent;
    [SerializeField] Image fill;

    [SerializeField] DialogueChannel dialogueChannel;

    // variables
    [SerializeField] float decrSpeed, incrAmt;
    [SerializeField] float decrHealth;
    [SerializeField] float minRand, maxRand;
    [SerializeField] public float lerpSpeed;
    [SerializeField] string winStatus, loseStatus, doingWellStatus, inTroubleStatus, inSuperTroubleStatus;

    private float currAngle, currHealthAngle, healthAngleCap; // angles work in negatives where you think the value would be positive, and vice versa
    private float randTime, t;
    private SafeArea sa;

    void Start()
    {
        fill.color = new Color(0, 1, 1, 1);
        statusText.text = inSuperTroubleStatus;
    }

    void OnEnable()
    {
        timer.enabled = false;
        timerText.text = timer.amountTime.ToString();

        button.interactable = false;

        t = 0f;

        health.interactable = false;
        health.maxValue = 50;
        //health.value = health.maxValue;
        health.value = 0;

        currAngle = 0;

        currHealthAngle = 0;

        safeArea.transform.rotation = Quaternion.Euler(0f, 0f, currHealthAngle);

        sa = safeArea.GetComponent<SafeArea>();
        //c = width, a & b = height --- cosine law solving for angle C --- /2 because the pivot is in the center
        healthAngleCap = ( (Mathf.Acos( ( Mathf.Pow(sa.GetSide(),2) + Mathf.Pow(sa.GetSide(),2) - Mathf.Pow(sa.GetBase(),2) ) / ( 2 * sa.GetSide() * sa.GetSide() ) )) * Mathf.Rad2Deg ) / 2;
        //Debug.Log(healthAngleCap);

        randTime = Random.Range(minRand, maxRand);
    } // OnEnable

    void Update()
    {
        if (!parent.GetPlayable())
        {
            return;
        }

        needle.transform.rotation = Quaternion.Euler(0f, 0f, currAngle);
        safeArea.transform.rotation = Quaternion.Lerp(safeArea.transform.rotation, Quaternion.Euler(0f, 0f, currHealthAngle), t * lerpSpeed);
    } // Update

    void FixedUpdate()
    {
        if (!parent.GetPlayable())
        {
            return;
        }

        button.interactable = true;

        t += Time.deltaTime;

        randTime -= Time.deltaTime;

        if (health.value >= health.maxValue) // new
        {
            statusText.text = winStatus;
            button.interactable = false;

            MinigameManager.current.isWon = true;

            EventManager.current.EndDial();
        }

        //// loss
        //if (health.value <= 0)
        //{
        //    statusText.text = loseStatus;
        //    button.interactable = false;

        //    MinigameManager.current.isWon = false;

        //    EventManager.current.EndDial();
        //}

        // win
        //else if (timer.GetTime() <= 0)
        //{
        //    statusText.text = winStatus;
        //    button.interactable = false;

        //    MinigameManager.current.isWon = true;

        //    EventManager.current.EndDial();

        //}

        else
        {
            if (randTime <= 0)
            {
                currHealthAngle = Random.Range(-90 + healthAngleCap, 90 - healthAngleCap);
                randTime = Random.Range(minRand, maxRand);
            }

            health.value -= decrHealth * Time.deltaTime;

            if (currAngle < 0)
            {
                currAngle += decrSpeed * Time.deltaTime;
            }

            if (health.value >= health.maxValue * .75)
            {
                // color = orange
                fill.color = new Color(1, 0.5f, 0, 1);
            }
            else if (health.value >= health.maxValue / 2)
            {
                statusText.text = doingWellStatus;
                // color = yellow
                fill.color = new Color(1, 1, 0, 1);
            }
            else if (health.value <= health.maxValue / 4)
            {
                statusText.text = inSuperTroubleStatus;
                // color = blue
                fill.color = new Color(0, 1, 1, 1);
            }
            else
            {
                statusText.text = inTroubleStatus;
                // color = green
                fill.color = new Color(0, 1, 0, 1);

            }

        }

    } // FixedUpdate

    public void IncrementDial()
    {
        if (currAngle > -180)
        {
            currAngle -= incrAmt;
        }
    } // IncrementDial

}