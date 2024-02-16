using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEditor;

public class EventManager : MonoBehaviour
{
    //One instance of the class
    public static EventManager current;
    //int currAnimation = 0;
    public int currCase = 1;

    private void Awake()
    {
        current = this;
    }

    private DialogueNode node;

    public void GetNode(DialogueNode saveNode)
    {
        node = saveNode;
    }

    [SerializeField]
    GameObject dialMinigame, puzzleMinigame, asteroidMinigame;

    //[SerializeField]
    //GameObject[] animatedGO;

    //---------------------- Events --------------------------//

    public event Action<GameObject> animationPlay;
    public void AnimationPlay()
    {
        animationPlay?.Invoke(node.DialogueLine.animatedGO);
    }

    public event Action animationStop;
    public void AnimationStop()
    {
        animationStop?.Invoke();
        //currAnimation++;
    }

    public event Action<DialogueNode> canvasShake;
    public void ShakeCanvas()
    {
        canvasShake?.Invoke(node);
    }

    public event Action<DialogueNode> setCharacter;
    public void SetCharacters()
    {
        setCharacter?.Invoke(node);
    }

    public event Action<DialogueNode> character1SpriteChange;
    public void Character1SpriteChange()
    {
        character1SpriteChange?.Invoke(node);
    }

    public event Action<DialogueNode> character2SpriteChange;
    public void Character2SpriteChange()
    {
        character2SpriteChange?.Invoke(node);
    }

    public event Action<DialogueNode> handsSpriteChange;
    public void HandsSpriteChange()
    {
        handsSpriteChange?.Invoke(node);
    }

    public event Action<DialogueNode> characterAnimation;
    public void CharacterAnimation()
    {
        characterAnimation?.Invoke(node);
    }


    public event Action characterFadeInC1;
    public void CharacterFadeInC1()
    {
        characterFadeInC1?.Invoke();
    }

    public event Action characterFadeOutC1;
    public void CharacterFadeOutC1()
    {
        characterFadeOutC1?.Invoke();
    }

    public event Action characterFadeInC2;
    public void CharacterFadeInC2()
    {
        characterFadeInC2?.Invoke();
    }

    public event Action characterFadeOutC2;
    public void CharacterFadeOutC2()
    {
        characterFadeOutC2?.Invoke();
    }

    public event Action handsFadeIn;
    public void HandsFadeIn()
    {
        handsFadeIn?.Invoke();
    }

    public event Action handsFadeOut;
    public void HandsFadeOut()
    {
       handsFadeOut?.Invoke();
    }

    public event Action endGame;
    public void EndGame()
    {
        endGame?.Invoke();
    }

    public event Action nextCase;
    public void NextCase()
    {
        UnityEngine.Debug.Log(AssetDatabase.GetAssetPath(node));
        currCase = (int)Char.GetNumericValue(AssetDatabase.GetAssetPath(node)[49]); // based off folder name
        //Assets/ScriptableObjects/Narration/Dialogue/Case x
        nextCase?.Invoke();
    }

    // -------------------- Minigames -------------------- //
    //asteroid
    public event Action<GameObject> asteroid;
    public void Asteroid()
    {
        asteroid?.Invoke(asteroidMinigame);
    }

    public event Action<GameObject> endAsteroid;
    public void EndAsteroid()
    {
        endAsteroid?.Invoke(asteroidMinigame);
    }
    //end asteroid

    //dial
    public event Action<GameObject> dial;
    public void Dial()
    {
        dial?.Invoke(dialMinigame);
    }

    public event Action<GameObject> endDial;
    public void EndDial()
    {
        endDial?.Invoke(dialMinigame);
    }
    //end dial

    public event Action<GameObject> puzzle;
    public void Puzzle()
    {
        puzzle?.Invoke(puzzleMinigame);
    }

    public event Action<GameObject> endPuzzle;
    public void EndPuzzle()
    {
        endPuzzle?.Invoke(puzzleMinigame);
    }
    //end puzzle

    //verdict
    //public event Action verdict;
    //public void Verdict()
    //{
    //    verdict?.Invoke();
    //}

    //public event Action endVerdict;
    //public void EndVerdict()
    //{
    //    endVerdict?.Invoke();
    //}
    //end verdict

    public event Action<bool> canDialogue;
    public void CanDialogue(bool can)
    {
        canDialogue?.Invoke(can);
    }

    public event Action click;
    public void MouseClick()
    {
        click?.Invoke();
    }

    public event Action nextClick;
    public void NextClick()
    {
        nextClick?.Invoke();
    }

    public event Action<bool> dialogueClick;
    public void DialogueClick(bool can)
    {
        dialogueClick?.Invoke(can);
    }

    public event Action debug;
    public void Debug()
    {
        debug?.Invoke();
    }

    public event Action sceneLoad;
    public void SceneLoaded()
    {
        sceneLoad?.Invoke();
    }
}
