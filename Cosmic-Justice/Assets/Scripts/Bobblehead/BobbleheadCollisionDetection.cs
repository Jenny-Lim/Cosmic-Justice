using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbleheadCollisionDetection : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hi");
        FollowMouseObject f = collision.gameObject.GetComponent<FollowMouseObject>();
        if (f != null) { AudioManager.instance.Play("Bobblehead"); }
    }
}
