using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickEffect : MonoBehaviour
{
    private ParticleSystem particles;
    private Vector2 mousePos;

    public static ClickEffect instance;

    private bool virtualMouse;

    public InputActionAsset input;

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

        if (VirtualMouse.instance != null)
            virtualMouse = true;
        else
            virtualMouse = false;
    }

    private void OnDestroy()
    {
        //unsubscribe to the click event
        //EventManager.current.click -= onClick;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space) || input.FindAction("Interact").WasReleasedThisFrame())
        {
            onClick();
        }
    }

    //Plays particle at mouse location
    private void onClick()
    {
        var emission = particles.emission;

        if (!virtualMouse)
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        else
            mousePos = VirtualMouse.instance.mousePosition.position;
        transform.position = mousePos;
        particles.Emit(1);

        AudioManager.instance.Play("ClickSound");
    }
}
