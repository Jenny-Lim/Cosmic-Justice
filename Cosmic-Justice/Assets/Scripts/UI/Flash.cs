using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    private Image image;
    [SerializeField] private CanvasRenderer text;

    void OnEnable()
    {
        image = GetComponent<Image>();
        StartCoroutine("FlashCORO");
    }

    IEnumerator FlashCORO()
    {
        while (true) {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            //text.cull = false;
            yield return new WaitForSeconds(2f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
            //text.cull = true;
            yield return new WaitForSeconds(2f);
        }
    }
}
