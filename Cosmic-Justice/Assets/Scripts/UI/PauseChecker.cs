using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseChecker : MonoBehaviour
{
    private SceneLoader sceneLoader;

    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Button returnButton;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = SceneLoader.instance.GetComponent<SceneLoader>();

        sceneLoader.isPaused = false;

        resumeButton.onClick.AddListener(ResumeButtonClicked);
        returnButton.onClick.AddListener(QuitToMenuClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (sceneLoader.isPaused == false)
            {
                sceneLoader.Pause();
                Debug.Log("paused");
                return;
            }

            if (sceneLoader.isPaused == true)
            {
                sceneLoader.Resume(); 
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
