using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBlindButton : MonoBehaviour
{
    Button b;
    [SerializeField] GameObject colorWheel;
    // Start is called before the first frame update
    void Start()
    {
        b = GetComponent<Button>();
        b.onClick.AddListener(()=>OnClick());
    }

    void OnClick()
    {
        if (colorWheel.activeInHierarchy) colorWheel.SetActive(false);
        else colorWheel.SetActive(true);
    }
}
