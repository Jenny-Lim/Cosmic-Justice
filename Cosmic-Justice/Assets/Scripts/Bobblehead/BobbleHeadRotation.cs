using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbleHeadRotation : MonoBehaviour
{
    public Rigidbody box;
    public GameObject head;
    float yRot, xRot, zRot;
    Quaternion targetRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(box.rotation);
        yRot = head.transform.rotation.y;
        xRot = head.transform.rotation.x;
        zRot = head.transform.rotation.z;
        
        if(yRot > 0)
        {
            box.angularVelocity = Vector3.zero;
            box.MoveRotation(Quaternion.Euler(0, 45, 0));
            Debug.Log("1");
        }
        if (yRot < -180)
        {
            box.angularVelocity = Vector3.zero;
            box.MoveRotation(Quaternion.Euler(0, -45, 0));
            Debug.Log("2");
        }

        if (xRot > 90)
        {
            box.angularVelocity = Vector3.zero;
            box.rotation = Quaternion.Euler(-45, 0, 0);
            Debug.Log("3");
        }
        if (xRot < -90)
        {
            box.angularVelocity = Vector3.zero;
            box.rotation = Quaternion.Euler(45, 0, 0);
            Debug.Log("4");
        }

        if (zRot < 0)
        {
            box.angularVelocity = Vector3.zero;
            box.rotation = Quaternion.Euler(0, 0, 45);
            Debug.Log("5");

        }
        if (zRot > 180)
        {
            box.angularVelocity = Vector3.zero;
            box.rotation = Quaternion.Euler(0, 0, -45);
            Debug.Log("6");
        }
    }
}
