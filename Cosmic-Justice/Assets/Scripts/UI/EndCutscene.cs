using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Video;

public class EndCutscene : MonoBehaviour
{
    private VideoPlayer player;

    private float videoLength;

    private SceneLoader sceneLoader;

    public InputActionAsset input;

    private bool videoPlaying;

    // Start is called before the first frame update
    void Awake()
    {
        videoPlaying = true;
        player = GetComponent<VideoPlayer>();
        videoLength = (float) player.clip.length;
        sceneLoader = FindAnyObjectByType<SceneLoader>();
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(videoLength);
        sceneLoader.StartLoadLevel(2);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0) || input.FindAction("Interact").WasReleasedThisFrame())
        {
            if (videoPlaying)
            {
                videoPlaying = false;
                //player.Stop();
                StopAllCoroutines();
                sceneLoader.StartLoadLevel(2);
            }
        }
    }
}
