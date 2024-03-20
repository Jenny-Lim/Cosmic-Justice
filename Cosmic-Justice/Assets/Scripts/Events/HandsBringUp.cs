using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HandsBringUp : MonoBehaviour
{
    private Image cImage;
    Vector3 startPos;
    [SerializeField]
    private float fadeTime = 1.5f;

    [SerializeField] Vector3 moveUpBy;

    private float timeElapsed = 0, t;

    private bool fadeIn = false;
    private bool fadeOut = false;

    private bool canSpeedUp;

    // Start is called before the first frame update
    void Start()
    {
        cImage = gameObject.GetComponent<Image>();
        EventManager.current.handsFadeIn += fadeInHands;
        EventManager.current.handsFadeOut += fadeOutHands;
        canSpeedUp = true;
        startPos = this.transform.position;
    }

    private void OnDestroy()
    {
        EventManager.current.handsFadeIn -= fadeInHands;
        EventManager.current.handsFadeOut -= fadeOutHands;
    }

    private void CanSpeedUp(bool can)
    {
        canSpeedUp = can;
    }

    private void fadeInHands()
    {
        StartCoroutine(StartFadeIn());
    }

    private void fadeOutHands()
    {
        StartCoroutine(StartFadeOut());
    }

    private void Quicken()
    {
        if (fadeIn || fadeOut)
            if (canSpeedUp)
                timeElapsed = fadeTime - 0.001f;
    }

    private IEnumerator StartFadeIn()
    {
        while (fadeOut)
            yield return null;

        yield return StartCoroutine(doFadeIn());
    }

    private IEnumerator StartFadeOut()
    {
        while (fadeIn)
            yield return null;

        yield return StartCoroutine(doFadeOut());
    }

    private IEnumerator doFadeIn()
    {
        timeElapsed = 0;
        fadeIn = true;

        while (timeElapsed < fadeTime)
        {
            timeElapsed += Time.deltaTime;
            t = timeElapsed / fadeTime;
            this.transform.position = Vector3.Lerp(startPos, startPos + moveUpBy, t);

            yield return null;

        }
        this.transform.position = startPos + moveUpBy;
        fadeIn = false;

    }

    private IEnumerator doFadeOut()
    {
        timeElapsed = 0;
        fadeOut = true;

        while (timeElapsed < fadeTime)
        {
            timeElapsed += Time.deltaTime;
            t = timeElapsed / fadeTime;
            this.transform.position = Vector3.Lerp(startPos + moveUpBy, startPos, t);

            yield return null;

        }
        this.transform.position = startPos;
        fadeOut = false;

    }
}
