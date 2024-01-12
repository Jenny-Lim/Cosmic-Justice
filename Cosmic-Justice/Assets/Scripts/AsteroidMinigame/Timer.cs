using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public float amountTime = 60f; // made public

    private TextMeshProUGUI text;

    private float tempTime;

    private bool paused;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        tempTime = amountTime;
    }

    private void OnEnable()
    {
        tempTime = amountTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Keep making the timer go down. When it ends then end the asteroid event
        if (tempTime >= 0 && !paused)
        {
            tempTime -= Time.deltaTime;

           
        }

        text.text = ((int)tempTime).ToString();
        //else
        //{
        //    //EventManager.current.EndDial();
        //    EventManager.current.EndAsteroid();
        //}
    }

    public float GetTime()
    {
        return tempTime;
    }

    public void SetTime(float time) // new
    {
        tempTime = time;
    }

    public void PauseTime()
    {
        paused = true;
    }

    public void UnpauseTime()
    {
        paused = false;
    }
}
