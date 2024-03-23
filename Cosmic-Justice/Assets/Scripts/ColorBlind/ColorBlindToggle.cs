using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBlindToggle : MonoBehaviour
{
    Toggle t;
    [SerializeField] GameObject colorList;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Toggle>();
        t.isOn = SettingsSaver.instance.IsColorBlind;
        colorList.SetActive(t.isOn);
    }

    public void ValueChanged(bool val)
    {
        SettingsSaver.instance.SetColorBlind(t.isOn);
        colorList.SetActive(t.isOn);
    }
}
