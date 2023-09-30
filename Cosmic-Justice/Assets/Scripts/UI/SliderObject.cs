using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderObject : MonoBehaviour
{
    private Slider slider;
    [SerializeField] float decrSpeed;
    [SerializeField] float incrBy;
    [SerializeField] TMP_Text statusText;
    [SerializeField] Button button;
    [SerializeField] float yippeeRange; // temp

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue;
    }

    void FixedUpdate()
    {
        // decrement until 0
        if (slider.value <= 0)
        {
            statusText.text = "You lose.";
            button.enabled = false;
        }

        else
        {
            slider.value -= decrSpeed * Time.deltaTime;

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

        }

    }

    public void IncrementSlider()
    {
        slider.value += incrBy;
    }
}
