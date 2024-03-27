//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/PlayerController.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerController: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""VirtualMouse"",
            ""id"": ""c3e42165-785a-477f-8689-f79ef9e73e40"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""48722aae-a305-45af-a2a3-084edd4dba60"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""84211cea-5f52-4df6-957e-bb64672a3251"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShipForward"",
                    ""type"": ""Button"",
                    ""id"": ""700a6439-c701-4b09-9d75-4efc485270b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShipRight"",
                    ""type"": ""Button"",
                    ""id"": ""3c226181-1ae0-4ee1-9f27-68f17e13ceef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShipLeft"",
                    ""type"": ""Button"",
                    ""id"": ""0b165082-1393-4ed0-bfdd-fca5fe704030"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b688110e-4872-4e86-873f-7ddb31a8a714"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skip"",
                    ""type"": ""Button"",
                    ""id"": ""08362a2f-94d4-4f34-94f5-d3cee3276bf2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CutsceneSpeed"",
                    ""type"": ""Button"",
                    ""id"": ""3937eb24-b049-4b37-a7e1-79341473faf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CutsceneSlow"",
                    ""type"": ""Button"",
                    ""id"": ""d8a6143b-dbb8-4f61-bfc1-3fc34b1e2ac2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ab03f42c-4c10-433e-86a4-6564c3753f17"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c801262-1b44-4d50-a6ae-b2761832f1f5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""909db7bd-07c3-4580-ad16-9617188b1fa0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de3c23d2-f355-4591-ad96-05ed85a75e6d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56416fa4-517b-43af-bffe-12dff50b63b4"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""ShipForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b59b6abd-cb95-4a9a-a8d1-fe8255c603ea"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShipRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f048b38-98b5-4698-97a1-e953d51cad1e"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShipRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cc44ee3-483b-4260-a2e3-196d1d707263"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShipRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba54d7b0-6093-4036-b22a-a4c1f8e11ebf"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShipLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d3081c1-6ef6-4031-9812-47a44318bc8c"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShipLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bec2e705-fd7e-47b9-adc7-c1137d61a7a7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShipLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c93b918-a938-4361-962d-294be1bab9d9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShipForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e802c07-21c8-43ed-bed5-4ffaf519df30"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShipForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b21321dc-05b6-4644-93df-8c97c33f4b08"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72a7e132-7220-4c8f-975e-d3ad3ff4653b"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""018b55a0-0d9b-4caf-981d-2aff2213b627"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfed2bad-3473-410c-8ecb-811a3642e88e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ffc4be9-ee6c-4f5f-a5a2-b6e8c317de39"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CutsceneSpeed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a0e8e16-2850-4520-bfa6-c6e4a14a1528"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CutsceneSpeed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c546f48-2791-4f45-bb64-6ff7ae496146"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CutsceneSlow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ec605d0-9eed-4d90-97c5-2ae765cf0d9d"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CutsceneSlow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player"",
            ""bindingGroup"": ""Player"",
            ""devices"": []
        }
    ]
}");
        // VirtualMouse
        m_VirtualMouse = asset.FindActionMap("VirtualMouse", throwIfNotFound: true);
        m_VirtualMouse_Move = m_VirtualMouse.FindAction("Move", throwIfNotFound: true);
        m_VirtualMouse_Interact = m_VirtualMouse.FindAction("Interact", throwIfNotFound: true);
        m_VirtualMouse_ShipForward = m_VirtualMouse.FindAction("ShipForward", throwIfNotFound: true);
        m_VirtualMouse_ShipRight = m_VirtualMouse.FindAction("ShipRight", throwIfNotFound: true);
        m_VirtualMouse_ShipLeft = m_VirtualMouse.FindAction("ShipLeft", throwIfNotFound: true);
        m_VirtualMouse_Pause = m_VirtualMouse.FindAction("Pause", throwIfNotFound: true);
        m_VirtualMouse_Skip = m_VirtualMouse.FindAction("Skip", throwIfNotFound: true);
        m_VirtualMouse_CutsceneSpeed = m_VirtualMouse.FindAction("CutsceneSpeed", throwIfNotFound: true);
        m_VirtualMouse_CutsceneSlow = m_VirtualMouse.FindAction("CutsceneSlow", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // VirtualMouse
    private readonly InputActionMap m_VirtualMouse;
    private List<IVirtualMouseActions> m_VirtualMouseActionsCallbackInterfaces = new List<IVirtualMouseActions>();
    private readonly InputAction m_VirtualMouse_Move;
    private readonly InputAction m_VirtualMouse_Interact;
    private readonly InputAction m_VirtualMouse_ShipForward;
    private readonly InputAction m_VirtualMouse_ShipRight;
    private readonly InputAction m_VirtualMouse_ShipLeft;
    private readonly InputAction m_VirtualMouse_Pause;
    private readonly InputAction m_VirtualMouse_Skip;
    private readonly InputAction m_VirtualMouse_CutsceneSpeed;
    private readonly InputAction m_VirtualMouse_CutsceneSlow;
    public struct VirtualMouseActions
    {
        private @PlayerController m_Wrapper;
        public VirtualMouseActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_VirtualMouse_Move;
        public InputAction @Interact => m_Wrapper.m_VirtualMouse_Interact;
        public InputAction @ShipForward => m_Wrapper.m_VirtualMouse_ShipForward;
        public InputAction @ShipRight => m_Wrapper.m_VirtualMouse_ShipRight;
        public InputAction @ShipLeft => m_Wrapper.m_VirtualMouse_ShipLeft;
        public InputAction @Pause => m_Wrapper.m_VirtualMouse_Pause;
        public InputAction @Skip => m_Wrapper.m_VirtualMouse_Skip;
        public InputAction @CutsceneSpeed => m_Wrapper.m_VirtualMouse_CutsceneSpeed;
        public InputAction @CutsceneSlow => m_Wrapper.m_VirtualMouse_CutsceneSlow;
        public InputActionMap Get() { return m_Wrapper.m_VirtualMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VirtualMouseActions set) { return set.Get(); }
        public void AddCallbacks(IVirtualMouseActions instance)
        {
            if (instance == null || m_Wrapper.m_VirtualMouseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_VirtualMouseActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @ShipForward.started += instance.OnShipForward;
            @ShipForward.performed += instance.OnShipForward;
            @ShipForward.canceled += instance.OnShipForward;
            @ShipRight.started += instance.OnShipRight;
            @ShipRight.performed += instance.OnShipRight;
            @ShipRight.canceled += instance.OnShipRight;
            @ShipLeft.started += instance.OnShipLeft;
            @ShipLeft.performed += instance.OnShipLeft;
            @ShipLeft.canceled += instance.OnShipLeft;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @Skip.started += instance.OnSkip;
            @Skip.performed += instance.OnSkip;
            @Skip.canceled += instance.OnSkip;
            @CutsceneSpeed.started += instance.OnCutsceneSpeed;
            @CutsceneSpeed.performed += instance.OnCutsceneSpeed;
            @CutsceneSpeed.canceled += instance.OnCutsceneSpeed;
            @CutsceneSlow.started += instance.OnCutsceneSlow;
            @CutsceneSlow.performed += instance.OnCutsceneSlow;
            @CutsceneSlow.canceled += instance.OnCutsceneSlow;
        }

        private void UnregisterCallbacks(IVirtualMouseActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @ShipForward.started -= instance.OnShipForward;
            @ShipForward.performed -= instance.OnShipForward;
            @ShipForward.canceled -= instance.OnShipForward;
            @ShipRight.started -= instance.OnShipRight;
            @ShipRight.performed -= instance.OnShipRight;
            @ShipRight.canceled -= instance.OnShipRight;
            @ShipLeft.started -= instance.OnShipLeft;
            @ShipLeft.performed -= instance.OnShipLeft;
            @ShipLeft.canceled -= instance.OnShipLeft;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @Skip.started -= instance.OnSkip;
            @Skip.performed -= instance.OnSkip;
            @Skip.canceled -= instance.OnSkip;
            @CutsceneSpeed.started -= instance.OnCutsceneSpeed;
            @CutsceneSpeed.performed -= instance.OnCutsceneSpeed;
            @CutsceneSpeed.canceled -= instance.OnCutsceneSpeed;
            @CutsceneSlow.started -= instance.OnCutsceneSlow;
            @CutsceneSlow.performed -= instance.OnCutsceneSlow;
            @CutsceneSlow.canceled -= instance.OnCutsceneSlow;
        }

        public void RemoveCallbacks(IVirtualMouseActions instance)
        {
            if (m_Wrapper.m_VirtualMouseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IVirtualMouseActions instance)
        {
            foreach (var item in m_Wrapper.m_VirtualMouseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_VirtualMouseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public VirtualMouseActions @VirtualMouse => new VirtualMouseActions(this);
    private int m_PlayerSchemeIndex = -1;
    public InputControlScheme PlayerScheme
    {
        get
        {
            if (m_PlayerSchemeIndex == -1) m_PlayerSchemeIndex = asset.FindControlSchemeIndex("Player");
            return asset.controlSchemes[m_PlayerSchemeIndex];
        }
    }
    public interface IVirtualMouseActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnShipForward(InputAction.CallbackContext context);
        void OnShipRight(InputAction.CallbackContext context);
        void OnShipLeft(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnSkip(InputAction.CallbackContext context);
        void OnCutsceneSpeed(InputAction.CallbackContext context);
        void OnCutsceneSlow(InputAction.CallbackContext context);
    }
}
