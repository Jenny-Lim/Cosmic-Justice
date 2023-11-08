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
    private PolygonCollider2D pc;
    private Vector2[] points;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(safeAreaWidth, rt.sizeDelta.y);

        pc = GetComponent<PolygonCollider2D>(); // reshape collider

        points = pc.points;

        points[0].x = -1 * (safeAreaWidth / 2);
        points[1].x = safeAreaWidth / 2;

        pc.points = points;
    } // Awake

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
