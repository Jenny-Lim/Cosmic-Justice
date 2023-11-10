using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterFadeIn : MonoBehaviour
{
    private Image cImage;

    [SerializeField]
    private float fadeTime = 1.5f;

    private float startValue;
    private float endValue;

    // Start is called before the first frame update
    void Start()
    {
        cImage = gameObject.GetComponent<Image>();
        EventManager.current.characterFadeIn += fadeIn;

        startValue = 0;
        endValue = 1;
    }

    private void OnDestroy()
    {
        EventManager.current.characterFadeIn -= fadeIn;
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
            float value = Mathf.Lerp(startValue, endValue, timeElapsed / fadeTime);
            cImage.color = new Color(cImage.color.r, cImage.color.g, cImage.color.b, value);

            yield return null;

        }

    }
}
