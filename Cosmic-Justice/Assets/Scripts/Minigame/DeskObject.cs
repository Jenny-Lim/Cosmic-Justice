using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskObject : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] Vector3 moveUpBy;
    [SerializeField] float totalTime_UP, totalTime_DOWN;
    float timePassed, t;
    bool enabled, bringDown;
    [HideInInspector]
    public bool broughtDown, broughtUp;

    void Awake()
    {
        startPos = this.transform.position;
    } // Awake

    void OnEnable()
    {

        StartCoroutine(WaitForInput());

    } // OnEnable

    IEnumerator WaitForInput()
    {

        while (MinigameManager.current.WaitForInput)
        {
            yield return null;
        }

        if(!MinigameManager.current.SkipMinigame)
            StartCoroutine("BringUpCORO"); 
    }

    IEnumerator BringUpCORO() 
    {
        broughtUp = false;

        timePassed = 0;

        while (timePassed < totalTime_UP) {
            timePassed += Time.deltaTime;
            t = timePassed / totalTime_UP;

            // lerp it up
            this.transform.position = Vector3.Lerp(startPos, startPos + moveUpBy, t);
            yield return null;
        }
        this.transform.position = startPos + moveUpBy;
        broughtUp = true;
    } // BringUpCORO

    public void BringDown()
    {
        StartCoroutine("BringDownCORO");
    } // BringDown

    IEnumerator BringDownCORO()
    {
        broughtDown = false;

        timePassed = 0;

        while (timePassed < totalTime_DOWN)
        {
            timePassed += Time.deltaTime;
            t = timePassed / totalTime_DOWN;

            // lerp it down
            this.transform.position = Vector3.Lerp(startPos + moveUpBy, startPos, t);
            yield return null;
        }

        this.transform.position = startPos;
        broughtDown = true;
    } // BringDownCORO
}
