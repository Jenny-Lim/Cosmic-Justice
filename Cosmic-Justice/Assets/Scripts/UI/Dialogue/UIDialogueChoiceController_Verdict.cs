using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDialogueChoiceController_Verdict : UIDialogueChoiceController
{
    // Start is called before the first frame update
    private void Start()
    {
        // override
    }

    private void OnClick()
    {
        // override
    }

    public void GoToNext()
    {
        m_DialogueChannel.RaiseRequestDialogueNode(m_ChoiceNextNode);
    } // manually go to next
}
