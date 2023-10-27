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

    private float currAngle, rangeStart, rangeEnd; // angles work in negatives where you think the value would be positive, and vice versa
    private float randTime;

    void Start()
    {
        health.interactable = false;
        health.maxValue = 50;
        health.value = 50;

        currAngle = -90;

        rangeStart = Random.Range(-1, -170);
        rangeEnd = Random.Range(rangeStart, -180);

        safeAreaStart.transform.rotation = Quaternion.Euler(0f, 0f, rangeStart);
        safeAreaEnd.transform.rotation = Quaternion.Euler(0f, 0f, rangeEnd);

        randTime = Random.Range(minRand, maxRand);
    }

    void Update()
    {
        Debug.Log("currAngle: " + currAngle);
        needle.transform.rotation = Quaternion.Euler(0f, 0f, currAngle);

        safeAreaStart.transform.rotation = Quaternion.Euler(0f, 0f, rangeStart);
        safeAreaEnd.transform.rotation = Quaternion.Euler(0f, 0f, rangeEnd);
    }

    void FixedUpdate()
    {
        randTime -= Time.deltaTime;
        if (randTime <= 0)
        { // get random vals again
            rangeStart = Random.Range(-1, -170);
            rangeEnd = Random.Range(rangeStart, -180);

            randTime = Random.Range(minRand, maxRand);
        }

        // loss
        if (currAngle >= 0 || health.value <= 0)
        {
            statusText.text = "You lose.";
            button.enabled = false;
            // make time stop
            // exit here
        }

        // win
        else if (timer.GetTime() <= 0)
        {
            statusText.text = "You Win!";
            button.enabled = false;
            // exit here
        }

        else
        {
            if (currAngle < 0)
            {
                currAngle += decrSpeed * Time.deltaTime;
            }

            // for health
            if (currAngle <= rangeStart && currAngle >= rangeEnd)
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