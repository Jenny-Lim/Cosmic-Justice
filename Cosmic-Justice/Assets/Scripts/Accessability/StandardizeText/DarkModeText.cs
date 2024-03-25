using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkModeText : MonoBehaviour
{
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {

        toggle = GetComponent<Toggle>();

        toggle.isOn = SettingsSaver.instance.IsDarkModeText;

    }

    public void ValueChanged(bool value)
    {

        if (toggle.isOn)
            SettingsSaver.instance.SetDarkModeText(1);
        else
            SettingsSaver.instance.SetDarkModeText(0);

    }
}
