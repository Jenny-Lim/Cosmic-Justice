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

    private bool mouseLeft;

    private bool mouseMoved;

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
        if(Camera.main != null)
            canvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (canvas.worldCamera == null)
            FindSceneCamera();

        //If mouse is moved
        if (Input.GetAxis("Mouse X") != 0.0f || Input.GetAxis("Mouse Y") != 0.0f)
        {
            if (MouseScreenCheck())
            {
                Vector3 mousePos = Input.mousePosition / canvas.scaleFactor;
                mousePosition.anchoredPosition = mousePos;

                mouseMoved = true;

                InputState.Change(virtualMouseTrue.virtualMouse.position, mousePos);
            }
        }
        else if(MouseScreenCheck())
        {
            mouseMoved = false;

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
            if (!mouseMoved)
                return true;

            if (!Cursor.visible)
            {
                Cursor.visible = true;
                mouseLeft = true;
            }


            return false;
        }
#else
        if (Input.mousePosition.x <= 0 || Input.mousePosition.y <= 0 || Input.mousePosition.x >= Screen.width - 1 || Input.mousePosition.y >= Screen.height - 1) {
            if (!mouseMoved)
                return true;    
        
            if(!Cursor.visible)
            {
                Cursor.visible = true;
                mouseLeft = true;
            }
        
            return false;
        }
#endif
        else
        {

            if (Cursor.visible)
            {
                Cursor.visible = false;

                if (mouseLeft)
                {
                    mouseLeft = false;
                    mouseTrail.enabled = false;

                    StartCoroutine(RenableTrail());
                }

            }


            return true;
        }
    }

    //Re-enables the trail 
    private IEnumerator RenableTrail()
    {
        yield return new WaitForSeconds(0.01f);
        mouseTrail.Clear();
        mouseTrail.enabled = true;
    }
}
