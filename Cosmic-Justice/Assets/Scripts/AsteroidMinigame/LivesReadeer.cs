using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesReadeer : MonoBehaviour
{
    [SerializeField]
    private AsteroidPlayer player;

    private TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
