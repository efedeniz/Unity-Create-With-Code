using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUp;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int wave = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(wave);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            wave++;
            SpawnEnemyWave(wave);   
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenareSpawnPosition(), enemyPrefab.transform.rotation);
        }

        Instantiate(powerUp, GenareSpawnPosition(), powerUp.transform.rotation);
    }

    private Vector3 GenareSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spwanPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPosition = new Vector3(spawnPosX, 0, spwanPosZ);

        return spawnPosition;
    }
}
