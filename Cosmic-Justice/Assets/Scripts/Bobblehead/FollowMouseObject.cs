using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseObject : MonoBehaviour
{
    Vector3 pos;
    public float speed = 1f;

    private Transform virtualMouse;

    void Start()
    {
        if(VirtualMouse.instance != null)
        {
            virtualMouse = VirtualMouse.instance.virtualmouse.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (virtualMouse == null)
            pos = Input.mousePosition;
        else
            pos = virtualMouse.position;

        pos.z = speed;

        if (virtualMouse == null)
            transform.position = Camera.main.ScreenToWorldPoint(pos);
        else
            transform.position = new Vector3(pos.x, pos.y, speed);
    }
}
