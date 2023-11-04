using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class DoTweenRotatePerform : MonoBehaviour
{
    [Header("Data"), SerializeField] public DOTweenRotate RotateData;

    [Space(10)]

    [Header("On Enabled")]
    [Header("Settings")] public bool TweenOnEnable = false;

    [Space(10)]
    
    [Header("On Tween Complete")]
    [Header("Settings")] public bool OnTweenCompleteEvent = false;
    [Header("Settings")] public UnityEvent OnTweenComplete;

    private Transform _targetTransform;
    private bool _isActivated;

    public void PerformTween(Transform targetTransform = null)
    {
        targetTransform.DOComplete();

        if(targetTransform) _targetTransform = targetTransform;
        else targetTransform = this.gameObject.transform;
        
        switch (RotateData.tweenType)
        {
            case DOTweenRotate.TweenType.Rotate:
                targetTransform.transform.DORotate(RotateData.Rotation, RotateData.Duration).onComplete = OnComplete;
                break;
            case DOTweenRotate.TweenType.PunchRotate:
                targetTransform.transform.DOPunchRotation(RotateData.Rotation, RotateData.Duration, RotateData.Vibration, RotateData.Elasticity).onComplete = OnComplete;
                break;
            case DOTweenRotate.TweenType.LocalRotate:
                targetTransform.transform.DOLocalRotate(RotateData.Rotation, RotateData.Duration).onComplete = OnComplete;
                break;
        }
    }

    private void OnEnable()
    {
        if(TweenOnEnable)
        {
            _isActivated = true;
            _targetTransform = this.gameObject.transform;
            PerformTween(_targetTransform);
        }
    }

    private void OnComplete()
    {
        if(OnTweenCompleteEvent && !_isActivated) OnTweenComplete.Invoke();
        if(_isActivated) _isActivated = false;
    }
}