using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayAndNightCycle : MonoBehaviour
{
    [SerializeField] private Gradient lightColor;
    [SerializeField] private GameObject light;

    private int days;

    public int Days => days;

    private float time = 0;
    private bool canChangeDay = true;

    public delegate void OnDayChanged();

    public OnDayChanged DayChanged;

    private void Update() 
    {
        if (time > 80) 
        {
            time = 0;
        }

        if ((int) time == 40 && canChangeDay) 
        {
            canChangeDay = false;
            DayChanged();
            days++;

        }

        if ((int)time == 45)
            canChangeDay = true;
        time += Time.deltaTime;
        light.GetComponent<Light2D>().color = lightColor.Evaluate(time * 0.01f); 
    }
}
