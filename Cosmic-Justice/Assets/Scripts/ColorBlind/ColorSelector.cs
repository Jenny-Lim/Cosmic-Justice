using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorSelector : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Image button;
    [SerializeField] Canvas c;
    GameObject colorWheelObj;
    Texture2D colorWheel;
    Color selectedColor;
    RectTransform thisRect;

    // Start is called before the first frame update
    public void Start()
    {
        colorWheelObj = this.gameObject;
        colorWheelObj.SetActive(false);
        colorWheel = colorWheelObj.GetComponent<Image>().sprite.texture;
        thisRect = GetComponent<RectTransform>();
    } // Start
    public void OnClick()
    {
        // bring up color wheel
        colorWheelObj.SetActive(true);
    } // OnClick

    public void OnPointerDown(PointerEventData p)
    {
        Vector2 result;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(thisRect, p.position, Camera.main, out result);
        result += thisRect.sizeDelta / 2;

        selectedColor = colorWheel.GetPixel((int)result.x, (int)result.y);
        button.color = selectedColor;
        SettingsSaver.instance.replacingColors[0] = selectedColor;
        colorWheelObj.SetActive(false);
    } // OnPointerDown

} // ColorSelector
