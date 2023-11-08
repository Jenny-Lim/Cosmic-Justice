using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    [SerializeField] Dial dial;

    [SerializeField] float incrHealth;
    [SerializeField] float safeAreaWidth;

    private RectTransform rt;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(safeAreaWidth, rt.sizeDelta.y);
    } // Start

    void OnTriggerStay2D()
    {
        dial.health.value += incrHealth * Time.deltaTime;
    } // OnTriggerStay2D

    public float GetBase()
    {
        return rt.sizeDelta.x;
    } // GetBase

    public float GetSide()
    {
        return Mathf.Sqrt( Mathf.Pow(rt.sizeDelta.x/2,2) + Mathf.Pow(rt.sizeDelta.y,2) ); // pythagorean theorem
    } // GetSide
}
