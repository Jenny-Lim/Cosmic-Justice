using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleDetection : MonoBehaviour
{

    int frames;
    int time;
    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Input.anyKey)
        {
            frames = frames + 1;
        }
        else
        {
            frames = 0;
            time = 0;

        }

        time = frames / 60;
        if(time >= 60)
        {
            Debug.Log("Idle detected, 60 seconds idle");
        }

    }
}
