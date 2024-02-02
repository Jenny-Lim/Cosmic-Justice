using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.LowLevel;
using UnityEditor;

public class VirtualMouse : MonoBehaviour
{

    public static VirtualMouse instance;

    private Canvas canvas;

    public GameObject virtualmouse;
    public RectTransform mousePosition;
    public RectTransform mouseTrailPos;
    public VirtualMouseInput virtualMouseTrue;
    public TrailRenderer mouseTrail;

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

        canvas = GetComponent<Canvas>();

        Cursor.visible = false;

    }

    private void Start()
    {
        EventManager.current.sceneLoad += FindSceneCamera;
        FindSceneCamera();
    }

    private void OnDestroy()
    {
        EventManager.current.sceneLoad -= FindSceneCamera;
    }

    private void FindSceneCamera()
    {
        canvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //If mouse is moved
        if (Input.GetAxis("Mouse X") != 0.0f || Input.GetAxis("Mouse Y") != 0.0f)
        {
            if (MouseScreenCheck())
            {
                Vector3 mousePos = Input.mousePosition / canvas.scaleFactor;
                mousePosition.anchoredPosition = mousePos;

                InputState.Change(virtualMouseTrue.virtualMouse.position, mousePos);
            }
        }
        else if(MouseScreenCheck())
        {
            //Constantly move the mouse to be at the virtual mouse
            Mouse.current.WarpCursorPosition(mousePosition.anchoredPosition);
            InputState.Change(Mouse.current.position, mousePosition.anchoredPosition);
        }

    }

    public bool MouseScreenCheck()
    {
#if UNITY_EDITOR
        if (Input.mousePosition.x <= 0 || Input.mousePosition.y <= 0 || Input.mousePosition.x >= Handles.GetMainGameViewSize().x - 1 || Input.mousePosition.y >= Handles.GetMainGameViewSize().y - 1)
        {
            if (!Cursor.visible)
            {
                Cursor.visible = true;
            }

            return false;
        }
#else
        if (Input.mousePosition.x <= 0 || Input.mousePosition.y <= 0 || Input.mousePosition.x >= Screen.width - 1 || Input.mousePosition.y >= Screen.height - 1) {
            if(!Cursor.visible)
            {
                Cursor.visible = true;
            }
        
            return false;
        }
#endif
        else
        {
            if(Cursor.visible)
            {
                Cursor.visible = false;
            }
            return true;
        }
    }
}
