using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseChecker : MonoBehaviour
{
    [SerializeField]
    GameObject SceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        SceneLoader.GetComponent<SceneLoader>().isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneLoader.GetComponent<SceneLoader>().isPaused == false)
            {
                SceneLoader.GetComponent<SceneLoader>().Pause();
                Debug.Log("paused");
                return;
            }

            if (SceneLoader.GetComponent<SceneLoader>().isPaused == true)
            {
                SceneLoader.GetComponent<SceneLoader>().Resume(); 
                Debug.Log("unpaused");
                return;
            }
        }
    }
}
