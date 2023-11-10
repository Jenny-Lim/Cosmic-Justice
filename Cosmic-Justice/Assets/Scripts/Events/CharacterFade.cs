using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterFade : MonoBehaviour
{
    private Image cImage;

    [SerializeField]
    private float fadeTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        cImage = gameObject.GetComponent<Image>();
        EventManager.current.characterFadeIn += fadeIn;
        EventManager.current.characterFadeOut += fadeOut;
    }

    private void OnDestroy()
    {
        EventManager.current.characterFadeIn -= fadeIn;
        EventManager.current.characterFadeOut -= fadeOut;
    }

    private void fadeIn()
    {
        StartCoroutine(doFadeIn());
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

    private void fadeOut()
    {
        StartCoroutine(doFadeOut());
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
