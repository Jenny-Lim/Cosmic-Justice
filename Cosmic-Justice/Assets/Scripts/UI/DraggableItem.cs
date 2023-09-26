using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 offset;
    Transform parentAfterDrag;
    public GameObject text;

    public void Start()
    {
        text.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        offset = transform.position - Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
        transform.position = Input.mousePosition + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        transform.SetParent(parentAfterDrag);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.SetActive(false);
    }
}
