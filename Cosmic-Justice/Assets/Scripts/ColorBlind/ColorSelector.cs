using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ColorSelector : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Image button;
    [SerializeField] Canvas c;
    [SerializeField] public TMP_Text text;
    GameObject colorWheelObj;
    Texture2D colorWheel;
    Color selectedColor;
    RectTransform thisRect;
    [HideInInspector] public int id;

    // Start is called before the first frame update
    public void Start()
    {
        colorWheelObj = this.gameObject;
        colorWheelObj.SetActive(false);
        colorWheel = colorWheelObj.GetComponent<Image>().sprite.texture;
        thisRect = GetComponent<RectTransform>();

        selectedColor = SettingsSaver.instance.replacingColors[id];
        button.color = selectedColor;
    } // Start

    //public void OnClick()
    //{
    //    // bring up color wheel
    //    colorWheelObj.SetActive(true);
    //} // OnClick

    public void OnPointerDown(PointerEventData p)
    {
        Vector2 result;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(thisRect, p.position, Camera.main, out result);
        result += thisRect.sizeDelta / 2;

        selectedColor = colorWheel.GetPixel((int)result.x, (int)result.y);
        button.color = selectedColor;
        SettingsSaver.instance.replacingColors[id] = selectedColor;
        SettingsSaver.instance.SetColors();
        colorWheelObj.SetActive(false);
    } // OnPointerDown

} // ColorSelector
