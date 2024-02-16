using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSelector : MonoBehaviour
{
    public static CaseSelector instance { get; private set; }

    public int setCase = 1;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);
    }
}
