using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasShake : MonoBehaviour
{
    //Hold transform location of UI element
    private RectTransform location;

    private void Awake()
    {
        location = GetComponent<RectTransform>();
    }

    private void Start()
    {
        //subscribe to the canvasShake event
        EventManager.current.canvasShake += StartShake;
    }

    private void OnDestroy()
    {
        //unsubscribe to the canvasShake event
        EventManager.current.canvasShake -= StartShake;
    }

    [SerializeField]
    private float magnitude = 5f;

    [SerializeField]
    private float shakeTime = 1.0f;

    //Starts the camera shake
    private void StartShake(DialogueNode node)
    {
        StartCoroutine(Shake());
    }

    //Does the camera shake
    private IEnumerator Shake()
    {
        Vector3 origin = location.localPosition;

        float elapsed = 0.0f;

        while (elapsed < shakeTime)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            location.localPosition = new Vector3(x + origin.x, y + origin.y, origin.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = origin;
    }
}
