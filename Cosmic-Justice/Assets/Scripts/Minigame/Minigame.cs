using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    private bool canPlay;

    // Start is called before the first frame update
    void Start()
    {
        canPlay = false;
    }

    public void SetPlayability(bool val)
    {
        canPlay = val;
    }

    public bool GetPlayable()
    {
        return canPlay;
    }
}
