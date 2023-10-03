using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float amountTime = 60f;

    private TextMeshProUGUI text;

    private float tempTime;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        tempTime = amountTime;
    }

    private void OnEnable()
    {
        tempTime = amountTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (tempTime >= 0)
        {
            tempTime -= Time.deltaTime;

            text.text = ((int)tempTime).ToString();
        }
        else
        {
            EventManager.current.EndAsteroid();
        }
    }

    public float GetTime()
    {
        return tempTime;
    }
}
