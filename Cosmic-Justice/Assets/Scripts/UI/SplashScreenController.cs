using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
    private static SplashScreenController instance;
    public static SplashScreenController Instance => instance;

    [HideInInspector] public bool pressed = false;

    GameObject bobblehead;
    void Start()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Awake()
    {
        bobblehead = GameObject.FindGameObjectWithTag("Bobblehead");
    }
    public void ShowCase(int caseNum)
    {
        gameObject.transform.GetChild(caseNum).gameObject.SetActive(true);
        bobblehead.SetActive(false);
    }

    public void SetPressed()
    {
        pressed = true;
        bobblehead.SetActive(true);
    }
}
