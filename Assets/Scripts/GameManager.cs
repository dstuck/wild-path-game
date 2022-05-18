using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool hasJourneyEnded;
    public float restartDelay = 0.5f;

    public void EndJourney()
    {
        if(!hasJourneyEnded)
        {
            hasJourneyEnded = true;
            FindObjectOfType<PartyController>().IsFrozen = true;
            Invoke("RestartJourney", restartDelay);
        }
    }

    public void EndGame()
    {
        if (!hasJourneyEnded)
        {
            hasJourneyEnded = true;
            FindObjectOfType<PartyController>().IsFrozen = true;
            Invoke("Restart", restartDelay);
        }
    }

    void RestartJourney()
    {
        hasJourneyEnded = false;
        FindObjectOfType<Timer>().Reset();
        FindObjectOfType<PartyController>().Reset();
    }

    void Restart()
    {
        hasJourneyEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
