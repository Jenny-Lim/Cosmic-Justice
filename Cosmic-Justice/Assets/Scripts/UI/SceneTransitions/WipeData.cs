using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WipeData", menuName = "Scriptable Objects/WipeData", order = 1)]
public class WipeData : ScriptableObject
{
    public ScreenWipe.FillMethod fillMethod = ScreenWipe.FillMethod.Horizontal;

    public int sceneIndex;
}
