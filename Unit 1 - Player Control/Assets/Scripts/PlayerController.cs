using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speedometer;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] private float speed;
    [SerializeField] List<WheelCollider> wheels;
    private Rigidbody veicleRb;
    private float verticalInput;
    private float horizontalInput;
    private float horsePower = 500f;
    private float turnSpeed = 100f;

    


    // Start is called before the first frame update
    void Start()
    {
        veicleRb = GetComponent<Rigidbody>();
        veicleRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(IsOnGround())
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            veicleRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput, ForceMode.Impulse);
            veicleRb.AddTorque(Vector3.up * horizontalInput * turnSpeed, ForceMode.Impulse);

            speed = veicleRb.velocity.magnitude * 3.6f;
            speedometer.text = "Speed: " + (int)speed + " km/h";

            rpm = (speed % 30) * 40;

            rpmText.text = "RPM: " + rpm;

            /* Move the vehicle forward
             transform.Translate(0, 0, 1);
             transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
             transform.Translate(Vector3.right * Time.deltaTime * horizontalInput);
             transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * turnSpeed);
            */
        }
    }

    private bool IsOnGround()
    {
        int wheelOnGround = 0;

        foreach(WheelCollider i in wheels)
        {
            if (i.isGrounded)
            {
                wheelOnGround++;
            }
        }

        if (wheelOnGround == 4) return true;
        return false;
    }



}
