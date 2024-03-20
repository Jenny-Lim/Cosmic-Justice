using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.PlayerSettings;

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
        //selectedColor = colorWheel.GetPixel( (int)( Input.mousePosition.x ), (int)( Input.mousePosition.y ));

        RaycastHit hit;
        Camera _cam = Camera.main; // Camera to use for raycasting
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(_cam.transform.position, ray.direction, out hit, 10000.0f);

        if (hit.collider)
        {
            selectedColor = colorWheel.GetPixel((int)hit.textureCoord2.x, (int)hit.textureCoord2.y); // Get color from texture
        }

        thisButton.color = selectedColor;
        colorWheelObj.SetActive(false);
    }
}
