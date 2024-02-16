using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotChecker : MonoBehaviour
{

    public bool puzzleComplete;

    public GameObject piece1, piece2, piece3, piece4, piece5, piece6, piece7, piece8;

    // Start is called before the first frame update
    void Start()
    {
        puzzleComplete = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(piece1.GetComponent<DraggableItem>().sendMessageToChecker == true &&
            piece2.GetComponent<DraggableItem>().sendMessageToChecker == true &&
            piece3.GetComponent<DraggableItem>().sendMessageToChecker == true &&
            piece4.GetComponent<DraggableItem>().sendMessageToChecker == true &&
            piece5.GetComponent<DraggableItem>().sendMessageToChecker == true &&
            piece6.GetComponent<DraggableItem>().sendMessageToChecker == true &&
            piece7.GetComponent<DraggableItem>().sendMessageToChecker == true &&
            piece8.GetComponent<DraggableItem>().sendMessageToChecker == true)
        {
            puzzleComplete = true;
            Debug.Log(puzzleComplete);
        }


    }


}
