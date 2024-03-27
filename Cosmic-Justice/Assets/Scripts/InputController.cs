using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private PlayerController playerController;

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

        playerController = new PlayerController();
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
        IsForward = playerController.VirtualMouse.ShipForward.IsPressed();
        IsLeft = playerController.VirtualMouse.ShipLeft.IsPressed();
        IsRight = playerController.VirtualMouse.ShipRight.IsPressed();

        IsInteract = playerController.VirtualMouse.Interact.WasReleasedThisFrame();
        IsPause = playerController.VirtualMouse.Pause.WasReleasedThisFrame();
        IsSkip = playerController.VirtualMouse.Skip.WasReleasedThisFrame();

        IsSpeed = playerController.VirtualMouse.CutsceneSpeed.IsPressed();
        IsSlow = playerController.VirtualMouse.CutsceneSlow.IsPressed();
    }
}
