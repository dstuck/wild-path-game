using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool hasJourneyEnded;
    public float restartDelay = 1.0f;

    public void EndJourney()
    {
        if(!hasJourneyEnded)
        {
            hasJourneyEnded = true;
            FindObjectOfType<PartyController>().IsFrozen = true;
            Invoke("RestartJourney", restartDelay);
        }
    }

    void RestartJourney()
    {
        Restart();
    }

    void Restart()
    {
        hasJourneyEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
