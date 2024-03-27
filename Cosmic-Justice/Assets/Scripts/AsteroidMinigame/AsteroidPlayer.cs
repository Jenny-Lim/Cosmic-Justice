using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroidPlayer : MonoBehaviour
{
    //Speed of player
    [SerializeField]
    private float forwardSpeed = 2.0f;

    [SerializeField]
    private float turningSpeed = 1.0f;

    private int Collected = 0;

    [SerializeField]
    private int NeedToCollect = 10;

    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;

    private Rigidbody2D rgBd;

    //Handles whether player is moving forward
    private bool isMoving;

    private float turningDir;

    [SerializeField] Timer timer;

    private void Awake()
    {
        rgBd = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Collected = 0;
        transform.localPosition = Vector3.zero;
        textMeshProUGUI.text = "Collected: " + Collected.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets if player is moving forward
        isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (isMoving)
        {
            AudioManager.instance.Play("Spaceship_Loop_A");            
        }

        //Gets if player turning to the left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turningDir = turningSpeed;
        }//Gets if player turning to the right
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turningDir = -turningSpeed;
        }
        else //Else player is not turning
        {
            turningDir = 0.0f;
        }

        if(timer.isActiveAndEnabled)
            if (timer.GetTime() <= 0) { EventManager.current.EndAsteroid(); }
    }

    private void FixedUpdate()
    {
        
        //Handles forward movement
        if (isMoving)
        {
            rgBd.AddForce(this.transform.up * forwardSpeed);
        }

        //Handles turning
        if (turningDir != 0.0f)
        {
            rgBd.AddTorque(turningDir * this.turningSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            AudioManager.instance.Play("Asteroid_Collect_A");
            Collected++;
            textMeshProUGUI.text = "Collected: " + Collected.ToString();
            Destroy(collision.gameObject);

            if(Collected >= NeedToCollect)
            {
                EventManager.current.EndAsteroid();
            }
        }
    }
}
