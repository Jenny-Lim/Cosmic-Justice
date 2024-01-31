using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMouse : MonoBehaviour
{

    public static VirtualMouse instance;
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
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
