using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.LowLevel;

public class VirtualMouse : MonoBehaviour
{

    public static VirtualMouse instance;

    private Canvas canvas;

    public GameObject virtualmouse;
    public RectTransform mousePosition;
    public RectTransform mouseTrailPos;
    public VirtualMouseInput virtualMouseTrue; 
    public TrailRenderer mouseTrail;

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

        canvas = GetComponent<Canvas>();

        Cursor.visible = false;

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
        if (Input.GetAxis("Mouse X") != 0 && Input.GetAxis("Mouse Y") != 0)
        {

            Vector3 mousePos = Input.mousePosition / canvas.scaleFactor;
            mousePosition.anchoredPosition = mousePos;

            virtualMouseTrue.enabled = false;
        }
        else
        {
            //Constantly move the mouse to be at the virtual mouse
            Mouse.current.WarpCursorPosition(mousePosition.anchoredPosition);
            InputState.Change(Mouse.current.position, mousePosition.anchoredPosition);

            virtualMouseTrue.enabled = true;
        }


    }

    private void LateUpdate()
    {
        //Constantly move the mouse to be at the virtual mouse
        Mouse.current.WarpCursorPosition(mousePosition.anchoredPosition);
        InputState.Change(Mouse.current.position, mousePosition.anchoredPosition);
    }
}
