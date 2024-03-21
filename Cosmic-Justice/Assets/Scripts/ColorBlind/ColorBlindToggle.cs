using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBlindToggle : MonoBehaviour
{
    Toggle t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Toggle>();
        t.isOn = SettingsSaver.instance.IsColorBlind;
    }

    public void ValueChanged(bool value)
    {
        SettingsSaver.instance.SetColorBlind(t.isOn);
    }
}
