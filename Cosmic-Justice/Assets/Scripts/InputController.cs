using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public InputActionAsset playerController;
    public static InputController instance { get; private set; }

    [HideInInspector]
    public bool IsForward;
    [HideInInspector]
    public bool IsRight;
    [HideInInspector]
    public bool IsLeft;

    [HideInInspector]
    public bool IsSkip;
    [HideInInspector]
    public bool IsPause;
    [HideInInspector]
    public bool IsInteract;

    [HideInInspector]
    public bool IsSpeed;
    [HideInInspector]
    public bool IsSlow;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        IsForward = playerController.FindAction("ShipForward").IsPressed();
        IsLeft = playerController.FindAction("ShipLeft").IsPressed();
        IsRight = playerController.FindAction("ShipRight").IsPressed();

        IsInteract = playerController.FindAction("Interact").WasReleasedThisFrame();
        IsPause = playerController.FindAction("Pause").WasReleasedThisFrame();
        IsSkip = playerController.FindAction("Skip").WasReleasedThisFrame();

        IsSpeed = playerController.FindAction("CutsceneSpeed").IsPressed();
        IsSlow = playerController.FindAction("CutsceneSlow").IsPressed();
    }


}
