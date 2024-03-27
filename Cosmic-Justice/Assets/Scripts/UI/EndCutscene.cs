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

    private bool videoPlaying;

    [SerializeField] private float speedUpValue = 2;

    private InputController input;

    // Start is called before the first frame update
    void Awake()
    {
        videoPlaying = true;
        player = GetComponent<VideoPlayer>();
        videoLength = player.frameCount;

        input = InputController.instance;
    }

    private void Update()
    {
        if(currFrame < videoLength)
        {
            currFrame = player.frame + 1;

            if (input.IsInteract)
            {
                if (videoPlaying)
                {
                    videoPlaying = false;
                    //player.Stop();
                    StopAllCoroutines();
                    SceneLoader.instance.StartLoadLevel(2);
                }
            }

            if (input.IsSpeed)
            {
                player.playbackSpeed = speedUpValue;
            }
            else
                player.playbackSpeed = 1;

            if (input.IsSlow)
            {
                player.playbackSpeed = 0;
            }
            else if(player.playbackSpeed != speedUpValue)
                player.playbackSpeed = 1;


        }
        else
        {
            SceneLoader.instance.StartLoadLevel(2);
        }
    }
}
