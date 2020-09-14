using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30f;
    private float leftBount = -15f;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       if(!playerController.gameOver)
       {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
       }

       if(transform.position.x < leftBount && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
