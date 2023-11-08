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
    [SerializeField] Timer timer;
    [SerializeField] public Slider health;
    [SerializeField] GameObject safeArea;

    // variables
    [SerializeField] float decrSpeed, incrAmt;
    [SerializeField] float decrHealth;
    [SerializeField] float minRand, maxRand;
    [SerializeField] float lerpSpeed;

    private float currAngle, currHealthAngle; // angles work in negatives where you think the value would be positive, and vice versa
    private float randTime, t;

    void Start() // use width to alter range, make range check a collider enter, keep range the same
    {
        t = 0f;

        health.interactable = false;
        health.maxValue = 50;
        health.value = health.maxValue;

        currAngle = 0;

        // Random.Range(-90, 90);
        currHealthAngle = 0;

        safeArea.transform.rotation = Quaternion.Euler(0f, 0f, currHealthAngle);

        randTime = Random.Range(minRand, maxRand);
    } // Start

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
            // make time stop
            // exit here
        }

        else
        {
            if (randTime <= 0)
            {
                currHealthAngle = Random.Range(-90, 90);
                randTime = Random.Range(minRand, maxRand);
            }

            health.value -= decrHealth * Time.deltaTime;

            if (currAngle < 0)
            {
                currAngle += decrSpeed * Time.deltaTime;
            }

            if (health.value >= health.maxValue / 2)
            {
                statusText.text = "Phew";
            }
            else
            {
                statusText.text = "Welp";
                
            }

        }

    } // FixedUpdate

    public void IncrementDial()
    {
        if (currAngle > -180)
        {
            currAngle -= incrAmt;
        }
    }

}