using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    private float speed = 3.0f;
    public  int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 playerPosition = player.transform.position;
        Vector3 eneymPosition = transform.position;
        enemyRb.AddForce((playerPosition - eneymPosition).normalized * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }
}
