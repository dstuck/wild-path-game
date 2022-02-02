using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvManager : MonoBehaviour
{
    public GameObject forestPrefab;
    public GameObject windPrefab;
    public int nForests;
    public int nWind;

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
        GenerateGameObjects(forestPrefab, nForests, 0.3f, 10.0f, 0.3f, 5.0f);
        GenerateGameObjects(windPrefab, nWind, 10.0f, 20.0f, 0.3f, 5.0f);
    }

    void GenerateGameObjects(GameObject envObj, int nObjs, float minX, float maxX, float minY, float maxY) {
        for (int i = 0; i < nObjs; i++)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            Vector2 spawnPoint = new Vector2(x, y);
            GameObject obj = Instantiate(envObj, spawnPoint, Quaternion.identity);
            envObjects.Add(obj);
        }
    }
}
