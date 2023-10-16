using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  
    public Transform spawnPoint;     
    public float spawnInterval = 3.0f;  
    public int maxEnemies = 10;      
    private int currentEnemyCount = 0; 

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        if (currentEnemyCount < maxEnemies)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            currentEnemyCount++;
        }
    }
}
