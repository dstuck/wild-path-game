using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;using UnityEngine;

public class Timer : MonoBehaviour
{
    public Slider slider;

    private float decayPerSecond = 1.0f;

    public float DecayPerSecond
    {
        get { return decayPerSecond; }
        set
        {
            if (value < 0)
                decayPerSecond = 0;
            else
                decayPerSecond = value;
        }
    }

    private void Start()
    {
        SetMaxTime(30.0f);
        Reset();
    }

    void FixedUpdate()
    {
        slider.value -= decayPerSecond * Time.deltaTime;
        if(slider.value <= 0.0f)
        {
            FindObjectOfType<GameManager>().EndJourney();
        }
    }

    public void Reset()
    {
        slider.value = slider.maxValue;
    }

    public void SetMaxTime(float maxTime)
    {
        slider.maxValue = maxTime;
    }
}
