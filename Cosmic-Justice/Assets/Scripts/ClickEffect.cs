using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    private ParticleSystem particles;
    private Vector2 mousePos;

    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();    
    }

    // Update is called once per frame
    void Update()
    {
        var emission = particles.emission;

        if(Input.GetMouseButtonUp(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
            particles.Emit(1);
        }
    }
}
