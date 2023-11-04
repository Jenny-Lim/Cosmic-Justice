using DG.Tweening;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ScaleData", menuName = "Scriptable Objects/Tweening/DOTweenScaleData")]
public class DOTweenScale : ScriptableObject
{
    public enum TweenType
    {
        ShakeScale,
        PunchScale,
        TargetScale,
        TargetRect,

    }

    [Header("Type")]
    public TweenType tweenType;

    [Header("Target"), Tooltip("Is the target a text object?")]
    public bool isTargetText;
    
    [Header("~Shared Settings")] public bool changeColor = true;
    [Header("~Shared Settings")] public Color ShakeColor;
    [Header("~Shared Settings")] [Range(0, 10)] public float Duration = 1f;
    [Header("~Shared Settings")] [Range(0, 10)] public int Vibration = 5;

    [Header("~ShakeScale Settings")]  public ShakeRandomnessMode ShakeRandomnessMode;
    [Header("~ShakeScale Settings")] [Range(0, 10)] public float Randomness = 0;
    [Header("~ShakeScale Settings")] [Range(0, 10)] public float Strength = .5f;

    [Header("~PunchScale Settings")] public Vector3 punchScale;
    [Header("~PunchScale Settings")] [Range(0, 10)] public float Elasticity = 1f;

    [Header("~TargetScale Settings")] public Vector3 targetScale;

    [Header("~TargetScale Settings")] public Vector2 originalSize;
    [Header("~TargetScale Settings")] public Vector2 targetSize;
}
