using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField]
    private float magnitude = 5f;

    [SerializeField]
    private float shakeTime = 1.0f;

    public IEnumerator Shake()
    {
        Vector3 origin = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < shakeTime)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, origin.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = origin;
    }
}
