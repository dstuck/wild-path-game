using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;using UnityEngine;

public class Timer : MonoBehaviour
{
    public Slider slider;
    public float defaultMaxTime = 20.0f;

    private float decayPerSecond = 1.0f;

    GameManager gameManager;

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
        gameManager = FindObjectOfType<GameManager>();

        SetMaxTime(defaultMaxTime);
        Reset();
    }

    void FixedUpdate()
    {
        switch (gameManager.State)
        {
            case GameState.PreLaunch:
                break;
            case GameState.Traveling:
                slider.value -= decayPerSecond * Time.deltaTime;
                if (slider.value <= 0.0f)
                {
                    gameManager.EndJourney();
                }
                break;
            case GameState.Reseting:
                break;
            default:
                Debug.Log("Shouldn't be here in case statement");
                break;
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
