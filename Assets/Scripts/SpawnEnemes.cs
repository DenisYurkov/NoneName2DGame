using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemes : MonoBehaviour
{
    public GameObject enem;
    public float spawnTime = 5f;
    public float spawnDelay = 3f;


    private void Start()
    {
        InvokeRepeating("SpamEnem", spawnDelay, spawnTime);
       
    }

    void SpamEnem()
    {
        for (int i = 0; i < 1; i++)
        {
            float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(enem, spawnPosition, Quaternion.identity);
        }
    }
}
