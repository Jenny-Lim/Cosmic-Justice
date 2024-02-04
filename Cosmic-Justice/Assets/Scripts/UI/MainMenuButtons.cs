using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button select01Button;
    [SerializeField] protected Button creditButton;
    [SerializeField] private Button exitButton;


    private void Awake()
    {
        playButton.onClick.AddListener(PlayClicked);
        select01Button.onClick.AddListener(SelectCase01Clicked);
        creditButton.onClick.AddListener(CreditClicked);
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

    private void CreditClicked()
    {
        SceneLoader.instance.Credits();
    }

    private void QuitClicked()
    {
        SceneLoader.instance.QuitGame();
    }
}
