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
        dial.timer.enabled = true;
        dial.timer.UnpauseTime();
        dial.health.value += incrHealth * Time.deltaTime;
    } // OnTriggerStay2D

    void OnTriggerExit2D(Collider2D collision)
    {
        //dial.timer.SetTime(dial.timer.amountTime); // maybe dont reset
        dial.timer.PauseTime();
        if (dial.lerpSpeed > 0) {
            Debug.Log(dial.lerpSpeed);
            dial.lerpSpeed -= dial.lerpSpeed * 0.2f; // everytime you fail, lerpspeed slower
        }
    } // OnTriggerExit2D

    public float GetBase()
    {
        return rt.sizeDelta.x;
    } // GetBase

    public float GetSide()
    {
        return Mathf.Sqrt( Mathf.Pow(rt.sizeDelta.x/2,2) + Mathf.Pow(rt.sizeDelta.y,2) ); // pythagorean theorem
    } // GetSide
}
