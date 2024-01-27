using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HandSprites
{
    public string name;
    public int FramesPerSecond;
    public Sprite[] sprite;
}

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Hands")]
public class Hands : ScriptableObject
{
    public HandSprites[] sprites;
}
