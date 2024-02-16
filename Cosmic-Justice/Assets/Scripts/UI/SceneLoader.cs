using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    // GameObject MasterSceneLoader;

    public bool isPaused;

    private float MusicVolume;
    private float SFXvolume;

    private ScreenWipe screenWipe;

    private bool transitioning;

    public static SceneLoader instance;

    public void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            if (instance.pauseMenu == null && this.pauseMenu != null)
                instance.pauseMenu = this.pauseMenu;

            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        transitioning = false;
        MusicVolume = 1.0f;
        SFXvolume = 1.0f;

        if(screenWipe == null) screenWipe = FindObjectOfType<ScreenWipe>();
    }

    private void Start()
    {
        EventManager.current.endGame += Credits;
    }

    private void OnDestroy()
    {
        EventManager.current.endGame -= Credits;
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
        StartLoadLevel(1);
        //SceneManager.LoadScene(2);
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

        if (VirtualMouse.instance != null)
        {
            TrailRenderer trail = VirtualMouse.instance.mouseTrail;
            trail.Clear();
            trail.enabled = false;
        }
        else
        {
            TrailRenderer trail = SC_CursorTrail.instance.trail;
            trail.Clear();
            trail.enabled = false;
        }

        isPaused = true;
        EventManager.current.CanDialogue(false);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        if (VirtualMouse.instance != null)
            VirtualMouse.instance.mouseTrail.enabled = true;
        else
            SC_CursorTrail.instance.trail.enabled = true;

        isPaused = false;
        EventManager.current.CanDialogue(true);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        if (VirtualMouse.instance != null)
            VirtualMouse.instance.mouseTrail.enabled = true;
        else
            SC_CursorTrail.instance.trail.enabled = true;

        StartLoadLevel(0);
    }

    public void LevelOne()
    {
        CaseSelector.instance.setCase = 1;
        StartLoadLevel(2);
    }

    public void LevelTwo()
    {
        CaseSelector.instance.setCase = 2;
        StartLoadLevel(2);
    }

    public void LevelThree()
    {
        CaseSelector.instance.setCase = 3;
        StartLoadLevel(2);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Credits()
    {
        StartLoadLevel(3);
    }



    public void StartLoadLevel(int levelIndex)
    {
        if (transitioning)
            return;

        transitioning = true;
        if(screenWipe != null)
            StartCoroutine(LoadLevel(levelIndex));
        else
            SceneManager.LoadScene(levelIndex);
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        SetScreenWipeData(levelIndex);

        screenWipe.ToggleWipe(true);
        while (!screenWipe.isDone)
            yield return null;

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;

        //Plays music or stops it depending on the level loading
        if (levelIndex == 0 || levelIndex == 1 || levelIndex == 3)
        {
            AudioManager.instance.Play("MainTheme");
            AudioManager.instance.Stop("Ambient_Track_A");
            AudioManager.instance.Stop("MiniGame_Track_A");
        }
        else
        {
            AudioManager.instance.Stop("MainTheme");
            AudioManager.instance.Play("Ambient_Track_A");
        }

        EventManager.current.endGame -= Credits;

        // Start loading the scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);
        while (!asyncLoad.isDone)
            yield return null;

        transitioning = false;
    }


    // Method that will be called when the scene has finished loading
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unsubscribe from the event to prevent it from being called if not needed
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Start an unwipe after a short delay to give the scene time to render
        StartCoroutine(UnwipeScene());
    }

    private IEnumerator UnwipeScene()
    {
        // Optionally wait for the end of the frame to ensure the scene is rendered
        yield return new WaitForEndOfFrame();

        // Now trigger the wipe effect to end
        screenWipe.ToggleWipe(false);
        print("wiping in.");

        EventManager.current.SceneLoaded();

        EventManager.current.endGame += Credits;
    }

    private void SetScreenWipeData(int levelIndex)
    {
        for (int i = 0; i < screenWipe.Data.Length; i++)
        {
            if(screenWipe.Data[i].sceneIndex == levelIndex)
            {
                screenWipe.fillMethod = screenWipe.Data[i].fillMethod;
                screenWipe.SetFillMethod();
            }
        }
    }

    private void Update()
    {
        Debug.Log(transitioning);
    }
}
