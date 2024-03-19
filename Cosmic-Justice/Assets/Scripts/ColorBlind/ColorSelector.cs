using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{
    [SerializeField] GameObject colorWheelObj;
    Texture2D colorWheel;
    Image thisButton;
    Color selectedColor;

    // Start is called before the first frame update
    public void Start()
    {
        colorWheelObj.SetActive(false);
        thisButton = gameObject.GetComponent<Image>();
        colorWheel = colorWheelObj.GetComponent<Image>().sprite.texture;
    } // Start
    public void OnClick()
    {
        // bring up color wheel
        colorWheelObj.SetActive(true);
    } // OnClick

    public void OnColorPick()
    {
        // onmouseclick, save color, change color of button to that color, and hide the color wheel image
        selectedColor = colorWheel.GetPixel( (int)( Input.mousePosition.x ), (int)( Input.mousePosition.y ));
        thisButton.color = selectedColor;
        colorWheelObj.SetActive(false);
    }
}
