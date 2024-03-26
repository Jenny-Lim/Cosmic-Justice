using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
    private static SplashScreenController instance;
    public static SplashScreenController Instance => instance;

    [HideInInspector] public bool pressed = false;
    void Start()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void ShowCase(int caseNum)
    {
        gameObject.transform.GetChild(caseNum).gameObject.SetActive(true);
    }

    public void SetPressed()
    {
        pressed = true;
    }
}
