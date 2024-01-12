using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class CharacterChangeAnimation : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private bool leftCharacter;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.characterAnimation += ChangeAnimation;
    }

    private void OnDestroy()
    {
        EventManager.current.characterAnimation -= ChangeAnimation;
    }

    private void ChangeAnimation(DialogueNode node)
    {

        if (leftCharacter)
        {
            Testing(node.DialogueLine.leftCharacterAnimation.ToString());
        }
        else
            Testing(node.DialogueLine.rightCharacterAnimation.ToString());
    }

    private void Testing(string test)
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && test == "Idle")
        {
            return;
        }

        animator.SetTrigger(test);
    }
}
