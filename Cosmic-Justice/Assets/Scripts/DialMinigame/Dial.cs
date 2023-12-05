using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dial : MonoBehaviour
{
    // objects
    [SerializeField] GameObject needle;
    [SerializeField] TMP_Text statusText;
    [SerializeField] Button button;
    [SerializeField] public Timer timer; // made public
    [SerializeField] public Slider health;
    [SerializeField] GameObject safeArea;

    //[SerializeField] BasicDialogueNode prevNode1, prevNode2, winNode, loseNode; // track who you picked
    [SerializeField] DialogueChannel dialogueChannel;

    // variables
    [SerializeField] float decrSpeed, incrAmt;
    [SerializeField] float decrHealth;
    [SerializeField] float minRand, maxRand;
    [SerializeField] float lerpSpeed;
    [SerializeField] string winStatus, loseStatus, doingWellStatus, inTroubleStatus;

    private float currAngle, currHealthAngle, healthAngleCap; // angles work in negatives where you think the value would be positive, and vice versa
    private float randTime, t;
    private SafeArea sa;

    void OnEnable() // use width to alter range, make range check a collider enter, keep range the same
    {
        //prevNode1.m_NextNode = null; // with this current system, this should be set before the minigame (so sprites are appropriate)
        //prevNode2.m_NextNode = null;
        timer.enabled = false; // new

        t = 0f;

        health.interactable = false;
        health.maxValue = 50;
        health.value = health.maxValue;

        currAngle = 0;

        // Random.Range(-90, 90);
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
        needle.transform.rotation = Quaternion.Euler(0f, 0f, currAngle);
        safeArea.transform.rotation = Quaternion.Lerp(safeArea.transform.rotation, Quaternion.Euler(0f, 0f, currHealthAngle), t * lerpSpeed);
    } // Update

    void FixedUpdate()
    {
        t += Time.deltaTime; // in fixed update pls

        randTime -= Time.deltaTime;

        // loss
        if (health.value <= 0)
        {
            statusText.text = loseStatus;
            button.enabled = false;
            // setting so's weird behaviour, probably due to timing -- make a minigame so with list of possible prev nodes, and win and lose node
            //prevNode1.m_NextNode = loseNode; // scuffed
            //prevNode2.m_NextNode = loseNode;

            //dialogueChannel.RaiseRequestDialogueNode(loseNode);
            MinigameManager.current.isWon = false;

            EventManager.current.EndDial();
        }

        // win
        else if (timer.GetTime() <= 0)
        {
            statusText.text = winStatus;
            button.enabled = false;
            //prevNode1.m_NextNode = winNode; // scuffed
            //prevNode2.m_NextNode = winNode;

            //dialogueChannel.RaiseRequestDialogueNode(winNode);
            MinigameManager.current.isWon = true;

            EventManager.current.EndDial();

        }

        else
        {
            if (randTime <= 0)
            {
                //currHealthAngle = Random.Range(-90, 90);
                currHealthAngle = Random.Range(-90 + healthAngleCap, 90 - healthAngleCap);
                //currHealthAngle = 90 - healthAngleCap;
                randTime = Random.Range(minRand, maxRand);
            }

            health.value -= decrHealth * Time.deltaTime;

            if (currAngle < 0)
            {
                currAngle += decrSpeed * Time.deltaTime;
            }

            if (health.value >= health.maxValue / 2)
            {
                statusText.text = doingWellStatus;
            }
            else
            {
                statusText.text = inTroubleStatus;
                
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