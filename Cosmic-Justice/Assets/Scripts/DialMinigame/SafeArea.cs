using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    [SerializeField] Dial dial;
    [SerializeField] float incrHealth;

    void OnTriggerStay2D()
    {
        dial.health.value += incrHealth * Time.deltaTime;
    } // OnTriggerStay2D
}
