using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class SliderObject : MonoBehaviour
{
    private Slider slider;
    private RectTransform sliderRT;
    [SerializeField] float decrSpeed;
    [SerializeField] float incrSpeed;

    [SerializeField] TMP_Text statusText;
    [SerializeField] Button button;
    [SerializeField] float yippeeRange;
    [SerializeField] Timer timer;

    [SerializeField] Slider health;

    private float rangeStart, rangeEnd, rangeSize;
    [SerializeField] GameObject safeArea;
    private RectTransform rangeRT;

    [SerializeField] float decrHealth;
    [SerializeField] float incrHealth;

    //maxRange = slider.maxValue and maxSize = slider.width -- lets set the system up like this
    //slider.value / slider.maxValue and rangeStart / slider.width should equal the same value (factor)
    //factor * rangestart = position AKA position along the width
    void Start()
    {
        slider = GetComponent<Slider>();
        sliderRT = GetComponent<RectTransform>();
        rangeRT = safeArea.GetComponent<RectTransform>();

        slider.maxValue = sliderRT.sizeDelta.x; // 1:1 relationship with slider and values
        slider.minValue = 0;

        slider.value = slider.maxValue;
        health.value = health.maxValue;

        rangeStart = Random.Range(slider.minValue, slider.maxValue); // how to get world coords with width
        rangeEnd = Random.Range(rangeStart, slider.maxValue);

        //factor is the ratio between max val and max width
        //rangeSize *= (slider.maxValue / sliderRT.sizeDelta.x);

        rangeRT.anchoredPosition = new Vector2(rangeStart, rangeRT.anchoredPosition.y);
        rangeSize = rangeEnd - rangeStart;
        rangeRT.sizeDelta = new Vector2(rangeSize, rangeRT.sizeDelta.y);
    }

    void Update() // check for handle collision w/ the range
    {
        // calculate position of safe area
        //float factor = slider.value / slider.maxValue;
        //rangeStart *= factor;
        //rangeRT.anchoredPosition = new Vector2(rangeStart, rangeRT.anchoredPosition.y);

        // adjust size accordingly -- for now, size does not change
        //rangeRT.sizeDelta = new Vector2(rangeSize, rangeRT.sizeDelta.y);
    }

    void FixedUpdate()
    {
        // loss
        if (slider.value <= 0 || health.value <= 0)
        {
            statusText.text = "You lose.";
            button.enabled = false;
            // make time stop
            // exit here
        }

        // win
        else if (timer.GetTime() <= 0)
        {
            statusText.text = "You Win!";
            button.enabled = false;
            // exit here
        }

        else
        {
            slider.value -= decrSpeed * Time.deltaTime;

            // for main
            if (slider.value >= slider.maxValue - yippeeRange)
            {
                statusText.text = "Yippee!";
            }
            else if (slider.value < slider.maxValue / 2) // have this defined in editor
            {
                statusText.text = "uh oh";
            }
            else
            {
                statusText.text = "Les gooo";
            }

            // for health
            if (slider.value >= rangeStart && slider.value <= rangeEnd)
            {
                health.value += incrHealth * Time.deltaTime;
            }
            else
            {
                health.value -= decrHealth * Time.deltaTime;
            }

        }

    }

    public void IncrementSlider()
    {
        slider.value += incrSpeed;
    }

}
