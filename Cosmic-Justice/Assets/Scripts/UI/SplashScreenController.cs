using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
    private static SplashScreenController instance;
    public static SplashScreenController Instance => instance;

    [HideInInspector] public bool pressed = false;

    GameObject bobblehead;

    int caseNum;
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
        this.caseNum = caseNum;
        gameObject.transform.GetChild(this.caseNum).gameObject.SetActive(true);
        bobblehead.SetActive(false);
    }

    IEnumerator Wipe()
    {
        ScreenWipe.instance.ToggleWipe(true);
        while (!ScreenWipe.instance.isDone)
            yield return null;
        ScreenWipe.instance.ToggleWipe(false);
    }

    public void SetPressed()
    {
        StartCoroutine("Wipe");
        pressed = true;
        gameObject.transform.GetChild(this.caseNum).gameObject.SetActive(false);
        bobblehead.SetActive(true);
    }
}
