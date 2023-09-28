using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderObject : MonoBehaviour
{
    private Slider slider;
    [SerializeField] float decrSpeed;
    [SerializeField] float incrBy;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue;
    }

    void Update()
    {
        // decrement until 0
        if (slider.value <= 0)
        {
            Debug.Log("You Lose bozo");
        }
        else
        {
            slider.value -= decrSpeed * Time.deltaTime;
        }

    }

    public void IncrementSlider()
    {
        slider.value += incrBy;
    }
}
