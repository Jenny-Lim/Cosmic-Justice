using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 offset;
    [HideInInspector] public Transform parentAfterDrag;
    public Image image;
    public GameObject text;
    public GameObject correctSlot;
    bool disableDrag = false;
    public bool sendMessageToChecker = false;


    public void Start()
    {
        text.SetActive(false);
        
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (disableDrag == false)
        {
            parentAfterDrag = transform.parent;
            //Debug.Log(parentAfterDrag);
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
            offset = transform.position - Input.mousePosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (disableDrag == false)
        {
            transform.position = Input.mousePosition + offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        //Debug.Log(parentAfterDrag);
        if(parentAfterDrag.gameObject == correctSlot)
        {
            disableDrag = true;
            sendMessageToChecker = true;
        }
        else
        {
            disableDrag = false;
            sendMessageToChecker = false;
        }
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
