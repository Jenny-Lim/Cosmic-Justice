using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dial : MonoBehaviour
{
    [SerializeField] GameObject needle;
    [SerializeField] TMP_Text statusText;
    [SerializeField] Button button;
    [SerializeField] Timer timer;
    [SerializeField] Slider health;
    [SerializeField] GameObject safeAreaStart, safeAreaEnd;

    [SerializeField] float decrSpeed, incrAmt;
    [SerializeField] float decrHealth, incrHealth;
    [SerializeField] float minRand, maxRand;
    [SerializeField] float lerpSpeed;

    private float currAngle, rangeStart, rangeEnd; // angles work in negatives where you think the value would be positive, and vice versa
    private float randTime, t;

    void Start() // use width to alter range, make range check a collider enter, keep range the same
    {
        //gameIsOver = false; // have a default safe area
        t = 0f;

        health.interactable = false;
        health.maxValue = 50;
        health.value = 50;

        currAngle = -90;

        rangeStart = Random.Range(0, -170);
        rangeEnd = Random.Range(rangeStart + 1, -180);

        safeAreaStart.transform.rotation = Quaternion.Euler(0f, 0f, rangeStart);
        safeAreaEnd.transform.rotation = Quaternion.Euler(0f, 0f, rangeEnd);

        randTime = Random.Range(minRand, maxRand);
    }

    void Update()
    {
        //Debug.Log("currAngle: " + currAngle);
        needle.transform.rotation = Quaternion.Euler(0f, 0f, currAngle);

            //safeAreaStart.transform.rotation = Quaternion.Euler(0f, 0f, rangeStart);
            safeAreaStart.transform.rotation = Quaternion.Lerp(safeAreaStart.transform.rotation, Quaternion.Euler(0f, 0f, rangeStart), t * lerpSpeed);

            //safeAreaEnd.transform.rotation = Quaternion.Euler(0f, 0f, rangeEnd);
            safeAreaEnd.transform.rotation = Quaternion.Lerp(safeAreaEnd.transform.rotation, Quaternion.Euler(0f, 0f, rangeEnd), t * lerpSpeed);

        t += Time.deltaTime; // in fixed update pls
    }

    void FixedUpdate()
    {
        randTime -= Time.deltaTime;
        //t += Time.deltaTime;

        //if (!gameIsOver)
        //{ // get random vals again
            if (randTime <= 0) // move into else
            {
                //rangeStart = Mathf.Lerp(rangeStart, Random.Range(0, -170), t * lerpSpeed);
                //rangeEnd = Mathf.Lerp(rangeEnd, Random.Range(rangeStart + 1, -180), t * lerpSpeed);

                rangeStart = Random.Range(0, -170);
                rangeEnd = Random.Range(rangeStart + 1, -180);

                randTime = Random.Range(minRand, maxRand);
            }

            //safeAreaStart.transform.rotation = Quaternion.Lerp(safeAreaStart.transform.rotation, Quaternion.Euler(0f, 0f, rangeStart), t * lerpSpeed);
            //safeAreaEnd.transform.rotation = Quaternion.Lerp(safeAreaEnd.transform.rotation, Quaternion.Euler(0f, 0f, rangeEnd), t * lerpSpeed);
        //}


        // loss
        if (currAngle >= 0 || health.value <= 0)
        {
            statusText.text = "You lose.";
            button.enabled = false;
            //gameIsOver = true;
            // make time stop
            // exit here
        }

        // win
        else if (timer.GetTime() <= 0)
        {
            statusText.text = "You Win!";
            button.enabled = false;
            //gameIsOver = true;
            // make time stop
            // exit here
        }

        else
        {
            if (currAngle < 0)
            {
                currAngle += decrSpeed * Time.deltaTime;
            }

            // for health
            if (currAngle <= rangeStart && currAngle >= rangeEnd) // could instead do this based on rotation
            {
                statusText.text = "Phew";
                health.value += incrHealth * Time.deltaTime;
            }
            else
            {
                statusText.text = "Welp";
                health.value -= decrHealth * Time.deltaTime;
            }

        }

    }

    public void IncrementDial()
    {
        if (currAngle > -180)
        {
            currAngle -= incrAmt;
        }
    }

}