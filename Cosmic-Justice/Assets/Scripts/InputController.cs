using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

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

    [SerializeField] private InputActionProperty shipforward;
    [SerializeField] private InputActionProperty shipright;
    [SerializeField] private InputActionProperty shipleft;
    [SerializeField] private InputActionProperty skip;
    [SerializeField] private InputActionProperty pause;
    [SerializeField] private InputActionProperty interact;
    [SerializeField] private InputActionProperty speed;
    [SerializeField] private InputActionProperty slow;

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

    // Update is called once per frame
    void Update()
    {
        IsForward = shipforward.action.IsPressed();
        IsLeft = shipleft.action.IsPressed();
        IsRight = shipright.action.IsPressed();

        IsInteract = interact.action.WasReleasedThisFrame();
        IsPause = pause.action.WasReleasedThisFrame();
        IsSkip = skip.action.WasReleasedThisFrame();

        IsSpeed = speed.action.IsPressed();
        IsSlow = slow.action.IsPressed();

    }


}
