using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// JENNY LOOK AT THIS

public class CharacterFade : MonoBehaviour
{
    private Image cImage;

    [SerializeField]
    private float fadeTime = 1.5f;

    private bool character1;

    private float timeElapsed = 0;

    private bool fadeIn = false;
    private bool fadeOut = false;

    private bool canSpeedUp;

    // Start is called before the first frame update
    void Start()
    {
        cImage = gameObject.GetComponent<Image>();
        EventManager.current.characterFadeInC1 += fadeInC1;
        EventManager.current.characterFadeOutC1 += fadeOutC1;

        EventManager.current.characterFadeInC2 += fadeInC2;
        EventManager.current.characterFadeOutC2 += fadeOutC2;

        EventManager.current.canDialogue += CanSpeedUp;

        EventManager.current.click += Quicken;

        if (transform.position.x < 0)
            character1 = true;
        else
            character1 = false;

        canSpeedUp = true;
    }

    private void OnDestroy()
    {
        EventManager.current.characterFadeInC1 -= fadeInC1;
        EventManager.current.characterFadeOutC1 -= fadeOutC1;

        EventManager.current.characterFadeInC2 -= fadeInC2;
        EventManager.current.characterFadeOutC2 -= fadeOutC2;
        EventManager.current.canDialogue -= CanSpeedUp;

        EventManager.current.click -= Quicken;
    }

    private void CanSpeedUp(bool can)
    {
        canSpeedUp = can;
    }

    private void fadeInC1()
    {
        if (character1)
        {
            StartCoroutine(StartFadeIn());
        }
    }

    private void fadeInC2()
    {
        if (!character1)
        {
            StartCoroutine(StartFadeIn());
        }
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

    private void fadeOutC1()
    {
        if (character1)
        {
            StartCoroutine(StartFadeOut());
        }
    }

    private void fadeOutC2()
    {
        if (!character1)
        {
            StartCoroutine(StartFadeOut());
        }
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

    private IEnumerator StartFadeIn()
    {
        while(fadeOut)
            yield return null;

        yield return StartCoroutine(doFadeIn());
    }

    private IEnumerator StartFadeOut()
    {
        while (fadeIn)
            yield return null;

        yield return StartCoroutine(doFadeOut());
    }

    private void Quicken()
    {
        if (fadeIn || fadeOut)
            if(canSpeedUp)
                timeElapsed = fadeTime - 0.001f;
    }
}
