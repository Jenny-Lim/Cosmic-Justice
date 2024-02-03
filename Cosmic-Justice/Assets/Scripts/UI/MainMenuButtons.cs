using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button select01Button;
    [SerializeField] private Button exitButton;


    private void Awake()
    {
        playButton.onClick.AddListener(PlayClicked);
        select01Button.onClick.AddListener(SelectCase01Clicked);
        exitButton.onClick.AddListener(QuitClicked);
    }

    private void PlayClicked()
    {
        SceneLoader.instance.PlayGame();
    }

    private void SelectCase01Clicked()
    {
        SceneLoader.instance.LevelOne();
    }

    private void QuitClicked()
    {
        SceneLoader.instance.QuitGame();
    }
}
