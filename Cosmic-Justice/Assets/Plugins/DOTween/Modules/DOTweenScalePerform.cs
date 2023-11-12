using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DOTweenScalePerform : MonoBehaviour
{
    [Header("-Data"), SerializeField] public DOTweenScale ScaleData;

    [Space(10)]

    [Header("-On Enabled")] [Space(6)]
    public bool TweenOnEnable = false;
    [Space(4)] public bool OnTweenStartEvent = false;
    [Space(4)] public UnityEvent OnTweenStart;
    
    [Header("-On Tween Complete")] [Space(6)]
    
    [Space(4)] public bool OnTweenCompleteEvent = false;
    [Space(4)] public bool AllowOnCompleteFromOnEnable = false;
    [Space(4)] public UnityEvent OnTweenComplete;

    [Space(6)]

    [Header("-Loop Settings")]
    public bool loopTween = false;

    private Color OriginalColor;
    private FontStyles originalFontStyle;
    private Transform _targetTransform;
    private bool _isActivated;
    private Image _targetImage;

    public void ShakeTransform(Transform targetTransform)
    {
        TextMeshProUGUI targetText;
        if(ScaleData.isTargetText) targetText = targetTransform.gameObject.GetComponent<TextMeshProUGUI>();
        else targetText = null;

        //Change Text Color
        if(ScaleData.changeColor && targetText != null) OriginalColor = targetText.color;
        if(ScaleData.changeColor && targetText != null) targetText.color = ScaleData.ShakeColor;


        //Change Text Style
        if(targetText != null) originalFontStyle = targetText.fontStyle;
        if(targetText != null) targetText.fontStyle = FontStyles.Bold;
        
        //Change Image Color
        TryGetComponent(out _targetImage);
        if(ScaleData.changeColor && _targetImage) OriginalColor = _targetImage.color;
        if(ScaleData.changeColor && _targetImage) _targetImage.color = ScaleData.ShakeColor;
        
        PerformTween(targetTransform);

        //Reset Text Style
        if(targetText != null) targetText.fontStyle = originalFontStyle;

        //Reset Text Color
        if(ScaleData.changeColor && targetText != null) targetText.DOColor(OriginalColor, ScaleData.Duration);
        if(ScaleData.changeColor && _targetImage) _targetImage.DOColor(OriginalColor, ScaleData.Duration);

    }

    public void PerformTween(Transform targetTransform = null, Image targetImage = null)
    {
        targetTransform.DOComplete();

        if(targetTransform) _targetTransform = targetTransform;

        Tweener tweener = null; // This will store the reference to the created tweener

        switch (ScaleData.tweenType)
        {
            case DOTweenScale.TweenType.ShakeScale:
                tweener = targetTransform.transform.DOShakeScale(ScaleData.Duration, ScaleData.Strength, ScaleData.Vibration, ScaleData.Randomness, false, ScaleData.ShakeRandomnessMode);
                break;
            case DOTweenScale.TweenType.PunchScale:
                tweener = targetTransform.transform.DOPunchScale(ScaleData.punchScale, ScaleData.Duration, ScaleData.Vibration, ScaleData.Elasticity);
                break;
            case DOTweenScale.TweenType.TargetScale:
                tweener = targetTransform.transform.DOScale(ScaleData.targetScale, ScaleData.Duration);
                break;
            case DOTweenScale.TweenType.TargetRect:
                var TargetRect = targetTransform.GetComponent<Image>();
                tweener = TargetRect.rectTransform.DOSizeDelta(ScaleData.targetSize, ScaleData.Duration);
                break;
        }

        if (tweener != null)
        {
            tweener.OnStart(OnStart);
            tweener.onComplete += OnComplete; // Assign onComplete callback

            // If loop is true, set the tween to loop indefinitely
            if (loopTween)
            {
                tweener.SetLoops(-1, LoopType.Restart); // Loop indefinitely
            }
        }
    }

    private void OnEnable()
    {
        if(TweenOnEnable)
        {
            _isActivated = true;
            _targetTransform = this.gameObject.transform;
            ShakeTransform(_targetTransform);
        }
    }

    private void OnStart()
    {
        if(OnTweenStartEvent)
        {
            if(!_isActivated) 
                OnTweenStart.Invoke();
        }
        if(_isActivated) _isActivated = false;
    }

    private void OnComplete()
    {
        if(OnTweenCompleteEvent) 
        {
            if(!_isActivated || AllowOnCompleteFromOnEnable) 
                OnTweenComplete.Invoke();
        }
        if(_isActivated) _isActivated = false;
    }
}