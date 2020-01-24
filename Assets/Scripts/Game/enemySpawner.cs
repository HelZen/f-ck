using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;

    public float spawnTime;
    public float spawnAmount;
    float timeInSeconds;

    void Update()
    {
        timeInSeconds += Time.deltaTime;
        if (timeInSeconds % spawnTime == 0)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
                Instantiate(enemy, randomPositionOnScreen, Quaternion.identity);
            }
        }
        
    }

}
