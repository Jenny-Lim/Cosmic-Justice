using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck : MonoBehaviour
{
    //public GameObject red, green, white;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("yeer");
        if (other.gameObject.name == "ItemRed")
        {
            transform.position = other.gameObject.transform.position;
            Debug.Log("yeeeeeeeeer");
        }
    }
}
