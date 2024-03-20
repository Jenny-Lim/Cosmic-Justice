using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandardiTextToggle : MonoBehaviour
{
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {

        toggle = GetComponent<Toggle>();

        toggle.isOn = SettingsSaver.instance.IsStandardized;

    }

    public void ValueChanged(bool value)
    {

        if (toggle.isOn)
            SettingsSaver.instance.SetStandardizedText(1);
        else
            SettingsSaver.instance.SetStandardizedText(0);
    }
}
