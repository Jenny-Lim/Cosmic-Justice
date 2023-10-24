using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    bool fullscreened;

    public void Awake()
    {
        fullscreened = true;
    }

    public void FullscreenToggle()
    {
        if (fullscreened == false)
        {
            Screen.fullScreen = true;
            fullscreened = true;
            Debug.Log("full");
        }
        else
        {
            Screen.fullScreen = false;
            fullscreened = false;
            Debug.Log("min");
        }

    }


}
