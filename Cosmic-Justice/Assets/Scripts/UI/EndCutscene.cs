using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Video;

public class EndCutscene : MonoBehaviour
{
    private VideoPlayer player;

    private float videoLength; //The total number of frames of the video
    private float currFrame; //The current frame of the video

    public InputActionAsset input;

    private bool videoPlaying;

    [SerializeField] private float speedUpValue = 2;

    // Start is called before the first frame update
    void Awake()
    {
        videoPlaying = true;
        player = GetComponent<VideoPlayer>();
        videoLength = player.frameCount;
    }

    private void Update()
    {
        if(currFrame < videoLength)
        {
            currFrame = player.frame + 1;

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0) || input.FindAction("Interact").WasReleasedThisFrame())
            {
                if (videoPlaying)
                {
                    videoPlaying = false;
                    //player.Stop();
                    StopAllCoroutines();
                    SceneLoader.instance.StartLoadLevel(2);
                }
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                player.playbackSpeed = speedUpValue;
            }
            else if (Input.GetKeyUp(KeyCode.W))
                player.playbackSpeed = 1;

        }
        else
        {
            SceneLoader.instance.StartLoadLevel(2);
        }
    }
}
