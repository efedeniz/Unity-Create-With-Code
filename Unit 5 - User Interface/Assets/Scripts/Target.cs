using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody targetRb;
    private float xRange = 4;
    private float ySpawnPosion = -2;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float torque = 10;
    
    public int pointVal;
    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed,maxSpeed), ForceMode.Impulse);
        targetRb.AddTorque(CreateTorquePoint(), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPosion, 0);

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointVal);
            Instantiate(particleSystem, transform.position, transform.rotation);
        } 
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Good"))
        {
            gameManager.GameOver();
        }
    }

    private Vector3 CreateTorquePoint()
    {
        float torqueX = Random.Range(-torque, torque);
        float torqueY = Random.Range(-torque, torque);
        float torqueZ = Random.Range(-torque, torque);
        return new Vector3(torqueX, torqueY, torqueZ);
    }
}
