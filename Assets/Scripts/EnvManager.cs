using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvManager : MonoBehaviour
{
    public GameObject forestPrefab;
    public float nForests;

    private List<GameObject> envObjects = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        RestartLevel();
    }

    public void RestartLevel()
    {
        foreach (GameObject envObj in envObjects)
        {
            Destroy(envObj);
        }
        for (int i = 0; i < nForests; i ++)
        {
            float x = Random.Range(0.3f, 10.0f);
            float y = Random.Range(0.3f, 5.0f);
            Vector2 spawnPoint = new Vector2(x, y);
            GameObject forest = Instantiate(forestPrefab, spawnPoint, Quaternion.identity);
            envObjects.Add(forest);
        }
    }
}
