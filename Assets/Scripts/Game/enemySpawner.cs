using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    public float spawnAmount;

    public void Start()
    {
        InvokeRepeating("SpawnEnemy", 2.5f, spawnTime);
    }

    void SpawnEnemy()
    {
        GameObject[] enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyCount.Length == 0)
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            Instantiate(enemy, randomPositionOnScreen, transform.rotation);
        }

    }


}
