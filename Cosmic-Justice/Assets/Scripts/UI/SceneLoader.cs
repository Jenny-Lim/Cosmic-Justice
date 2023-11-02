using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject MasterSceneLoader;

    public bool isPaused;

    private float MusicVolume;
    private float SFXvolume;

    public void Awake()
    {
        DontDestroyOnLoad(MasterSceneLoader);
        MusicVolume = 1.0f;
        SFXvolume = 1.0f;
    }

    private void OnDisable()
    {
       // SceneManager.LoadScene(1);
    }


    public void SetMusicVolume(float volume)
    {
        MusicVolume = volume;
    }

    public float GetMusicVolume() { return MusicVolume; }

    public void SetSFXVolume(float volume)
    {
        SFXvolume = volume;
    }

    public float GetSFXVolume() { return SFXvolume; }


    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    public void Restart()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(current);
        SceneManager.LoadScene(current);
       // pauseMenu.GetComponent<PauseScript>().ResumeGame();

    }



    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(3);
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Credits()
    {
        SceneManager.LoadScene(5);
    }

   
}
