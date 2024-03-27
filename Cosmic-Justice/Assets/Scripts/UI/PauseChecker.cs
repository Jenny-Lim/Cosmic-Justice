using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PauseChecker : MonoBehaviour
{
    private SceneLoader sceneLoader;

    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Button returnButton;

    private InputController input;

    [SerializeField]
    private Button nextButton;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = SceneLoader.instance.GetComponent<SceneLoader>();

        sceneLoader.isPaused = false;

        resumeButton.onClick.AddListener(ResumeButtonClicked);
        returnButton.onClick.AddListener(QuitToMenuClicked);

        input = InputController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (input.IsPause)
        {
            if (sceneLoader.isPaused == false)
            {
                sceneLoader.Pause();
                nextButton.interactable = false;
                Debug.Log("paused");
                return;
            }

            if (sceneLoader.isPaused == true)
            {
                sceneLoader.Resume();
                nextButton.interactable = true;
                Debug.Log("unpaused");
                return;
            }
        }
    }

    private void ResumeButtonClicked()
    {
        sceneLoader.Resume();
    }

    private void QuitToMenuClicked()
    {
        sceneLoader.MainMenu();
    }
}
