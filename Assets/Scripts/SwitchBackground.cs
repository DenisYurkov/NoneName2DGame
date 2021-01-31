using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBackground : MonoBehaviour
{
    public Sprite layer_day, layer_night;
    public GameObject SpawnEnemy;
    void Start()
    {
        Day();
    }

    void Day()
    {
        GetComponent<SpriteRenderer>().sprite = layer_day;
        Invoke("Night", 40f);
    }

    void Night()
    {
        GetComponent<SpriteRenderer>().sprite = layer_night;
        SpawnEnemy.SetActive(true);
        Invoke("Day", 300f);
    }
}

