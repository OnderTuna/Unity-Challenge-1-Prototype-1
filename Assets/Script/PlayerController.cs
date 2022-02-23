using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    [SerializeField] private float horsePower = 0;
    [SerializeField] float rpm;
    public float turnSpeed = 45.0f;
    public float horizontalInput;
    public float verticalInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelOnGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
            speed = playerRb.velocity.magnitude * 2.237f;
            speedometerText.text = "Speed: " + Mathf.Round(speed);
            rpm = (speed % 30) * 40;
            rpmText.text = "RPM: " + Mathf.Round(rpm);
        }
    }

    bool IsOnGround()
    {
        wheelOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelOnGround++;
            }
        }

        if (wheelOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
