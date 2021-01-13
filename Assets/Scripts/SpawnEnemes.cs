using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemes : MonoBehaviour
{
    public GameObject enem;
    public GameObject transformGameObject;
    
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
            Vector2 spawnPosition = new Vector2(transformGameObject.transform.position.x , transformGameObject.transform.position.y);
            Instantiate(enem, spawnPosition, Quaternion.identity);
        }
    }
}
