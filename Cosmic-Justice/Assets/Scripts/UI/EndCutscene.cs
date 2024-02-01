using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Video;

public class EndCutscene : MonoBehaviour
{
    private VideoPlayer player;

    private float videoLength;

    private SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0))
            sceneLoader.StartLoadLevel(2);
    }
}
