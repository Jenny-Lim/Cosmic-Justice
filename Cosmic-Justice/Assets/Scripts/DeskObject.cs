using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskObject : MonoBehaviour // for reverse functioning, inherit from this and override onenable + bringdown to do the opposite
{
    Vector3 startPos;
    [SerializeField] Vector3 moveUpBy;
    [SerializeField] float totalTime_UP, totalTime_DOWN;
    float timePassed, t;
    bool enabled, bringDown;
    public bool broughtDown, broughtUp;

    void Start()
    {
        startPos = this.transform.position;
    }

    void FixedUpdate()
    {
        if (enabled)
        {
            timePassed += Time.deltaTime;
            t = timePassed / totalTime_UP;

            // lerp it up
            this.transform.position = Vector3.Lerp(startPos, startPos + moveUpBy, t);

            if (timePassed >= totalTime_UP)
            {
                this.transform.position = startPos + moveUpBy;
                enabled = false;
                timePassed = 0;
                broughtUp = true;
            }
        }
        if (bringDown)
        {
            timePassed += Time.deltaTime;
            t = timePassed / totalTime_DOWN;

            // lerp it down
            this.transform.position = Vector3.Lerp(startPos + moveUpBy, startPos, t);

            if (timePassed >= totalTime_DOWN)
            {
                this.transform.position = startPos;
                bringDown = false;
                //timePassed = 0; // this gotta stay commented
                broughtDown = true;
            }
        }
    }
    void OnEnable() 
    {
        AudioManager.instance.Play("DeskMovementA");
        enabled = true;
    }

    public void BringDown()
    {
        AudioManager.instance.Play("DeskMovementA"); // probably want a different sound
        bringDown = true;
    }
}
