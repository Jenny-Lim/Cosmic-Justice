using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterFade : MonoBehaviour
{
    private Image cImage;

    [SerializeField]
    private float fadeTime = 1.5f;

    private bool character1;

    // Start is called before the first frame update
    void Start()
    {
        cImage = gameObject.GetComponent<Image>();
        EventManager.current.characterFadeInC1 += fadeInC1;
        EventManager.current.characterFadeOutC1 += fadeOutC1;

        EventManager.current.characterFadeInC2 += fadeInC2;
        EventManager.current.characterFadeOutC2 += fadeOutC2;

        if (transform.position.x < 0)
            character1 = true;
        else
            character1 = false;
    }

    private void OnDestroy()
    {
        EventManager.current.characterFadeInC2 -= fadeInC2;
        EventManager.current.characterFadeOutC2 -= fadeOutC2;
    }

    private void fadeInC1()
    {
        if (character1)
        {
            StartCoroutine(doFadeIn());
        }
    }

    private void fadeInC2()
    {
        if (!character1)
        {
            StartCoroutine(doFadeIn());
        }
    }

    private IEnumerator doFadeIn()
    {
        float timeElapsed = 0;

        while (timeElapsed < fadeTime)
        {
            timeElapsed += Time.deltaTime;
            float value = Mathf.Lerp(0, 1, timeElapsed / fadeTime);
            cImage.color = new Color(cImage.color.r, cImage.color.g, cImage.color.b, value);

            yield return null;

        }

    }

    private void fadeOutC1()
    {
        if (character1)
        {
            StartCoroutine(doFadeOut());
        }
    }

    private void fadeOutC2()
    {
        if (!character1)
        {
            StartCoroutine(doFadeOut());
        }
    }

    private IEnumerator doFadeOut()
    {
        float timeElapsed = 0;

        while (timeElapsed < fadeTime)
        {
            timeElapsed += Time.deltaTime;
            float value = Mathf.Lerp(1, 0, timeElapsed / fadeTime);
            cImage.color = new Color(cImage.color.r, cImage.color.g, cImage.color.b, value);

            yield return null;

        }

    }
}
