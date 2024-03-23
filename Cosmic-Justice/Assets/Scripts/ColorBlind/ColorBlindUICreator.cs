using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlindUICreator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private string[] colorStrings = { "Red", "Green", "Blue", "Yellow", "Orange", "Purple", "Cyan", "Black", "White"};
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject go = Instantiate(prefab, transform);
            ColorSelector cs = go.transform.GetChild(1).GetComponent<ColorSelector>();
            cs.id = i;
            cs.text.text = colorStrings[i];
        }
    } // Start
} // ColorBlindUICreator
