using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;


    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 5;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;


    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();



    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;


    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

   // Determines how many enemies to spawn based on the number of base enemies multipled by the current wave raised to the power of the scaling factor
    private int EnemiesPerWave()
    {
        //Raises the base (the current wave) to the difficulty scaling factor 
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }


    private void Start()
    {
        StartWave();
        StartCoroutine(StartWave());
    }


    void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0){
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }


        if(enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }


    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
    
    private void EndWave()
    {
        currentWave++;
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        StartCoroutine(StartWave());
    }

}
