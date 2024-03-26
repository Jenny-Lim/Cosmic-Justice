using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 offset;
    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField] Minigame parent;
    public Image image;
    public GameObject text;
    public GameObject correctSlot;
    public Transform PiecesPool;
    bool disableDrag = false;
    public bool sendMessageToChecker = false;

    private bool correctSpot;


    public void Start()
    {
        if(text != null)
            text.SetActive(false);

        correctSpot = false;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!parent.GetPlayable())
        {
            return;
        }
        if (correctSpot)
            return;

        if (disableDrag == false)
        {
            parentAfterDrag = transform.parent;
            //Debug.Log(parentAfterDrag);
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!parent.GetPlayable())
        {
            return;
        }
        if (correctSpot)
            return;

        if (disableDrag == false)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!parent.GetPlayable())
        {
            return;
        }
        Debug.Log("drop");

        if (correctSpot)
            return;

        if (parentAfterDrag.tag != "PuzzlePiece")
            transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        //Debug.Log(parentAfterDrag);
        if(parentAfterDrag.gameObject == correctSlot)
        {
            disableDrag = true;
            sendMessageToChecker = true;
            correctSpot = true;
        }
        else
        {
            disableDrag = false;
            sendMessageToChecker = false;
            transform.SetParent(PiecesPool);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!parent.GetPlayable())
        {
            return;
        }
        if (text != null)
            text.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!parent.GetPlayable())
        {
            return;
        }
        if (text != null)
            text.SetActive(false);
    }
}
