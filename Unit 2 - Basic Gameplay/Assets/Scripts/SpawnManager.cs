using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;
    private float spawnRangeX = 20.0f;
    // Start is called before the first frame update
    private float spawnPosZ = 20.0f;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnRandomAnimal(){
        GameObject animal = animals[Random.Range(0,animals.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX,spawnRangeX),0,spawnPosZ);
        Instantiate(animal,spawnPosition,animal.transform.rotation);
    }
}
