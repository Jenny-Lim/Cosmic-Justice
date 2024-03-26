using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMouseSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject virtualMouse_Prefab;

    private void Awake()
    {
        if(VirtualMouse.instance == null)
        {
            GameObject vM = Instantiate(virtualMouse_Prefab);

            vM.SetActive(true);
        }
    }
}
