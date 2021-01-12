using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBackground : MonoBehaviour
{
    public Sprite layer_day, layer_night;
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
        Invoke("Day", 40f);
    }
}

