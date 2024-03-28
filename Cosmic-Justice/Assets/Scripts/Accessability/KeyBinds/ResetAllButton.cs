using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetAllButton : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actionAsset;

    public void ResetAllBindings()
    {
        foreach (InputActionMap map in _actionAsset.actionMaps)
        {
            map.RemoveAllBindingOverrides();
        }
    }
}
