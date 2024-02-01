using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualMouse : MonoBehaviour
{

    public static VirtualMouse instance;

    private Canvas canvas;

    public GameObject virtualmouse;
    public RectTransform mousePosition;
    public RectTransform mouseTrailPos;

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

    }
}
