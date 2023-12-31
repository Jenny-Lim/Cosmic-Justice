using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 2.0f;

    [SerializeField]
    private int spawnAmount = 1;

    [SerializeField]
    private float spawnDistance = 430f;

    [SerializeField]
    private float trajectoryVariance = 15.0f;

    [SerializeField]
    private Asteroid asteroidPrefab;

    private RectTransform rectangle;

    // Start is called before the first frame update
    void Start()
    {
        rectangle = GetComponent<RectTransform>();
        InvokeRepeating(nameof(SpawnAsteroid), spawnRate, spawnRate);
    }

    private void SpawnAsteroid()
    {
        //Get position outside of screen
        float screenW = rectangle.rect.width;
        float screenH = rectangle.rect.height;

        //Debug.Log(screenW);

        for(int i = 0; i < spawnAmount; i++)
        {
            //Get the random position on the edge of a circle
            Vector3 randomCircle = Random.insideUnitCircle.normalized;

            //Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnDirection = new Vector3(randomCircle.x * screenW, randomCircle.y * screenH);
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            //Debug.Log(spawnPoint.x);
            Asteroid asteroid = Instantiate(this.asteroidPrefab, Camera.main.ScreenToWorldPoint(spawnPoint), rotation, this.transform.parent);

            if (asteroid != null)
            {
                asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
                asteroid.SetCollider();

                asteroid.SetTrajectory(rotation * -spawnDirection);
            }
        }
    }
}
