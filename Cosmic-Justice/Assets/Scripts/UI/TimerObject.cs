using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerObject : MonoBehaviour
{
    private TMP_Text timerText;
    private float timeRemaining;
    [SerializeField] float maxTime;
    [SerializeField] float timeDecrSpeed;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        timeRemaining = maxTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeRemaining -= timeDecrSpeed * Time.deltaTime;
        timerText.text = "Time Left: " + timeRemaining.ToString();
    }
}
