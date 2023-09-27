using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderObject : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider thisSlider;

    void Start()
    {
        thisSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // decrement until 0
        // if (thisSlider.value <= 0)
        {
            // lose minigame
        }
        //else
        {
            // decr.
        }

    }

    public void OnClick()
    {
        Debug.Log("ONClick");
        thisSlider.value += 0.5f;
    }
}
