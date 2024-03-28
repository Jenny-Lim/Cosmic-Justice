using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    [SerializeField] private Button nextButton;

    private InputController input;

    // Start is called before the first frame update
    void Start()
    {
        nextButton.onClick.AddListener(Click);

        input = InputController.instance;
    }

    private void Update()
    {

        if (input.IsSkip && !SceneLoader.instance.isPaused)
            EventManager.current.NextClick();
    }


    private void Click()
    {
        EventManager.current.NextClick();
    }
}
