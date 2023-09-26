using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoText : MonoBehaviour
{
    public GameObject thing;
    // Start is called before the first frame update
    void Start()
    {
        thing.SetActive(false);
    }

    public void OnMouseOver()
    {
        thing.SetActive(true);
    }

    public void OnMouseExit()
    {
        thing.SetActive(false);
    }
}
