using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Dial : MonoBehaviour
{
    [SerializeField] GameObject needle;

    [SerializeField] float decrSpeed;
    [SerializeField] float incrSpeed;

    [SerializeField] TMP_Text statusText;
    [SerializeField] Button button;
    //[SerializeField] float yippeeRange;
    [SerializeField] Timer timer;

    [SerializeField] Slider health;

    private float currAngle, rangeStart, rangeEnd;
    [SerializeField] GameObject safeAreaStart, safeAreaEnd;

    [SerializeField] float decrHealth;
    [SerializeField] float incrHealth;

    //private Vector2 pivotPt;
    void Start()
    {
        health.maxValue = 50;
        health.value = 50;

        //pivotPt = new Vector2(0,0.5f);

        currAngle = -90;

        rangeStart = Random.Range(-1, -170);
        rangeEnd = Random.Range(rangeStart, -180);

        //safeAreaStart.RotateAroundPivot(rangeStart, pivotPt);
        //safeAreaEnd.RotateAroundPivot(rangeEnd, pivotPt);

        safeAreaStart.transform.rotation = Quaternion.Euler(0f, 0f, rangeStart);
        safeAreaEnd.transform.rotation = Quaternion.Euler(0f, 0f, rangeEnd);
    }

    void Update()
    {
        //needle.RotateAroundPivot(currAngle, pivotPt);

        Debug.Log("currAngle: " + currAngle);
        needle.transform.rotation = Quaternion.Euler(0f, 0f, currAngle);
    }

    void FixedUpdate()
    {
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
                currAngle += decrSpeed * Time.deltaTime; // angle is reversed
            }

            // for main
            //if (currAngle >= 180 - yippeeRange)
            //{
            //    statusText.text = "Yippee!";
            //}
            //else if (currAngle < 180 / 2)
            //{
            //    statusText.text = "uh oh";
            //}
            //else
            //{
            //    statusText.text = "Les gooo";
            //}

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

    public void IncrementDial() // swap from slider in editor
    {
        if (currAngle > -180)
        {
            currAngle -= incrSpeed;
        }
    }

}