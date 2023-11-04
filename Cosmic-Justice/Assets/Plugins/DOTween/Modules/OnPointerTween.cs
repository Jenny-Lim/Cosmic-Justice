using UnityEngine;
using UnityEngine.EventSystems;

public class OnPointerTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    [SerializeField] private bool useScaleTween = true;
    [SerializeField] private bool useRotateTween;
    [SerializeField] private bool useMoveTween;

    [Space(10)]

    [Header("Scale")]

    [SerializeField] DOTweenScalePerform ScaleOnEnter;
    [SerializeField] DOTweenScalePerform ScaleOnExit;
    [SerializeField] DOTweenScalePerform ScaleOnDown;

    [SerializeField] DoTweenRotatePerform RotateOnEnter;
    [SerializeField] DoTweenRotatePerform RotateOnExit;
    [SerializeField] DoTweenRotatePerform RotateOnDown;

    // [SerializeField] DOTweenMovePerform MoveOnEnter;
    // [SerializeField] DOTweenMovePerform MoveOnExit;
    // [SerializeField] DOTweenMovePerform MoveOnDown;

    bool isTweening;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isTweening)
        {
            if(useScaleTween) ScaleOnEnter?.PerformTween(transform);

            if(useRotateTween) RotateOnEnter?.PerformTween(transform);

            // if(useMoveTween) MoveOnEnter?.PerformTween(transform, transform);

            isTweening = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(isTweening)
        {
            if(useScaleTween) ScaleOnExit?.PerformTween(transform);

            if(useRotateTween) RotateOnExit?.PerformTween(transform);

            // if(useMoveTween) MoveOnExit?.PerformTween(transform, transform);

            isTweening = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(ScaleOnDown || RotateOnDown)
        {
            if(useScaleTween) ScaleOnDown?.PerformTween(transform);

            if(useRotateTween) RotateOnDown?.PerformTween(transform);

            // if(useMoveTween) MoveOnDown?.PerformTween(transform, transform);
        }   
        
    }
}
