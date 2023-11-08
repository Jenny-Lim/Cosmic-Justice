using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    [SerializeField] Dial dial;
    [SerializeField] TMP_Text statusText;
    [SerializeField] float incrHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D()
    {
        //statusText.text = "Phew";
        dial.health.value += incrHealth * Time.deltaTime;
        Debug.Log(dial.health.value);
    }
}
