using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    private ParticleSystem particles;
    private Vector2 mousePos;

    public static ClickEffect instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        particles = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        //EventManager.current.click += onClick;
    }

    private void OnDestroy()
    {
        //unsubscribe to the click event
        //EventManager.current.click -= onClick;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            onClick();
        }
    }

    //Plays particle at mouse location
    private void onClick()
    {
        var emission = particles.emission;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        particles.Emit(1);

        AudioManager.instance.Play("ClickSound");
    }
}
