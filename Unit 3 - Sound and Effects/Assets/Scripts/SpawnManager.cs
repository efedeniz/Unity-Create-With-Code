using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject obstacle;
    private Vector3 spawnPostion = new Vector3(25, 0, 0);
    private float startDelay = 2f;
    private float repatRate = 4f;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        if (!playerController.gameOver)
        {
            Instantiate(obstacle, spawnPostion, obstacle.transform.rotation);
        }
    }
}
