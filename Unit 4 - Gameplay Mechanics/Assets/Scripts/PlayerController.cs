using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    private Rigidbody rBody;
    private float poweUpStrenght = 15.0f;
    private float speed = 10.0f;
    public bool hasPowerUp = false;

    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");

        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        powerUpIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);
        float verticalInput = Input.GetAxis("Vertical");
        rBody.AddForce(focalPoint.transform.forward* verticalInput * speed );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerupCounDownRoutine());
        }
    }

    IEnumerator PowerupCounDownRoutine()
    {
        yield return new WaitForSeconds(7.0f);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            GameObject enemy = collision.gameObject;
            Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = enemy.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * poweUpStrenght, ForceMode.Impulse);
        }
    }

}
