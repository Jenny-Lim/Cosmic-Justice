using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "RotationData", menuName = "Scriptable Objects/Tweening/DOTweenRotateData")]
public class DOTweenRotate : ScriptableObject
{
    public enum TweenType
    {
        Rotate,
        PunchRotate,
        LocalRotate,

    }

    [Header("Type")]
    public TweenType tweenType;

    [Header("~Shared Settings")] [Range(0, 10)] public float Duration = 1f;
    [Header("~Shared Settings")] [Range(0, 10)] public int Vibration = 5;
    [Header("~Shared Settings")] public Vector3 Rotation = new Vector3(360, 0, 0);
    [Header("~PunchRotate Settings")] [Range(0, 10)] public float Elasticity = 1f;
}
