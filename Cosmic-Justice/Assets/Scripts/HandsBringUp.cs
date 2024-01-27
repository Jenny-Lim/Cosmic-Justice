using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HandsBringUp : MonoBehaviour
{
    private Image cImage;
    [SerializeField]
    private float fadeTime = 1.5f;

    private float timeElapsed = 0;

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
            float value = Mathf.Lerp(0, 1, timeElapsed / fadeTime);
            cImage.color = new Color(cImage.color.r, cImage.color.g, cImage.color.b, value);

            yield return null;

        }

        fadeIn = false;

    }

    private IEnumerator doFadeOut()
    {
        timeElapsed = 0;
        fadeOut = true;

        while (timeElapsed < fadeTime)
        {
            timeElapsed += Time.deltaTime;
            float value = Mathf.Lerp(1, 0, timeElapsed / fadeTime);
            cImage.color = new Color(cImage.color.r, cImage.color.g, cImage.color.b, value);

            yield return null;

        }

        fadeOut = false;

    }
}
