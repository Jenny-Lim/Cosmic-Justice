using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    //Holds the different sprites of the asteroids
    [SerializeField]
    private Sprite[] asteroidSprites;

    [SerializeField]
    private float speed = 200f;

    [SerializeField]
    private float maxLifeTime = 30f;

    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    public float size = 1.0f;

    private Image imageSprite;

    private Rigidbody2D rgBd;

    private BoxCollider2D boxCollider;

    private RectTransform rectran;

    private void Awake()
    {
        //Get needed components
        imageSprite = GetComponent<Image>();
        rgBd = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        rectran = GetComponent<RectTransform>();
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        imageSprite.sprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];

        this.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        rgBd.mass = this.size * 2.0f;
    }

    public void SetTrajectory(Vector2 direction)
    {
        rgBd.AddForce(direction * speed);

        Destroy(this.gameObject, this.maxLifeTime);
    }

    public void SetCollider()
    {
        boxCollider.size = new Vector2(rectran.rect.width, rectran.rect.height);
    }


}
