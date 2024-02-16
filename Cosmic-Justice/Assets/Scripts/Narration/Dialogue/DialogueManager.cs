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
    private Dialogue case1;

    [SerializeField]
    private Dialogue case2;

    [SerializeField]
    private Dialogue case3;

    private Dialogue ToStart;

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
        //yield return new WaitForSeconds(0.2f);

        switch (CaseSelector.instance.setCase)
        {
            case (1):
                ToStart = case1;
                break;
            case (2):
                ToStart = case2;
                break;
            case (3):
                ToStart = case3;
                break;
        }

        yield return new WaitForSeconds(waitTime);
        dialogueChannel.RaiseRequestDialogue(ToStart);
    }
}
