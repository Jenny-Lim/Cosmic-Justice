using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 1.0f;

    [SerializeField]
    private DialogueChannel dialogueChannel;

    [SerializeField]
    private Dialogue dialogue;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitDialogueStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator waitDialogueStart()
    {
        yield return new WaitForSeconds(waitTime);
        dialogueChannel.RaiseRequestDialogue(dialogue);
    }
}
