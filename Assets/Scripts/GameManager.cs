using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    PreLaunch,
    Traveling,
    Reseting
}

public class GameManager : MonoBehaviour
{
    public float restartDelay = 0.5f;
    public GameState State { get; set; }

    void Start()
    {
        State = GameState.PreLaunch;
    }
    public void EndJourney()
    {
        if(State != GameState.Reseting)
        {
            State = GameState.Reseting;
            Invoke("RestartJourney", restartDelay);
        }
    }

    public void EndGame()
    {
        if (State != GameState.Reseting)
        {
            State = GameState.Reseting;
            Invoke("Restart", restartDelay);
        }
    }

    void RestartJourney()
    {
        State = GameState.PreLaunch;

        FindObjectOfType<Timer>().Reset();
        FindObjectOfType<PartyController>().Reset();
    }

    void Restart()
    {
        State = GameState.PreLaunch;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
