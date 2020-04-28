using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Variables
    public Wave[] waves; // Array of waves
    public Enemy enemy;

    Wave currentWave;
    int currentWaveNumber;

    int enemiesRemainingToSpawn;
    int enemiesRemainingAlive;
    float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn -= 1;
            nextSpawnTime = Time.time + currentWave.spawnTime;

            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }

    // OnEnemyDeath method
    void OnEnemyDeath()
    {
        enemiesRemainingAlive -= 1;
        if (enemiesRemainingAlive == 0)
        {
            NextWave();
        }
    }

    // NextWave method
    void NextWave()
    {
        currentWaveNumber += 1;
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];

            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;
        }
    }

    // Wave class
    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float spawnTime;
    }

}
