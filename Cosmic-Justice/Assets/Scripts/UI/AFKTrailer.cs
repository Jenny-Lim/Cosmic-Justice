using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;

public class AFKTrailer : MonoBehaviour
{
    public static AFKTrailer instance;

    private Canvas canvas;

    [SerializeField] private float timer = 20f;

    private float currTime;

    private bool trailerPlaying;

    [SerializeField]
    private VideoPlayer player;

    [SerializeField]
    private RawImage screen;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        canvas = GetComponent<Canvas>();

        trailerPlaying = false;
    }


    void Update()
    {

        if (Input.GetKeyUp(KeyCode.T) && !trailerPlaying)
        {
            trailerPlaying = true;
            screen.enabled = true;
            player.frame = 0;
            player.Play();
            currTime = timer + 1;
        }

        if (!Input.anyKey && Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0)
        {
            //Increase time
            if (currTime < timer)
            {
                currTime += Time.unscaledDeltaTime;
            }
            else if (currTime > timer && !trailerPlaying)
            {
                trailerPlaying = true;
                screen.enabled = true;
                player.frame = 0;
                player.Play();
            }
        }
        else
        {
            if(currTime != 0)
                currTime = 0;

            if (trailerPlaying)
            {
                trailerPlaying = false;
                player.Stop();
                screen.enabled = false;
            }
        }

    }

}
