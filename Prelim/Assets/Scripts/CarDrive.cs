using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{
    //public variables for easy access
    public float speed;
    public float turbo;
    public float turnSpeed;
    public float gravityMultiplier;

    private Rigidbody rb;

    void Start()
    {
        // getting the rigid body of the object
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //method calling in FixedUpdate for a smooth and constant code execution
        Accelerate();
        Turn();
        Fall();
    }

    void Accelerate ()
    {
        //acceleration method
        if (Input.GetKey(KeyCode.W))
        {
            //prevents movement for y axis while movement for x and z is implemented
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * speed * 10);
        }
        else if (Input.GetKey(KeyCode.S))
        {
              //prevents movement for y axis while movement for x and z is implemented
            rb.AddRelativeForce(-new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * speed * 10);
        }

                if (Input.GetKeyDown(KeyCode.Space))
        {
            //adds a boost to the object. When object is already at max speed, boost doesnt apply
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * turbo * 10);
        }
//removes the x axis force of relative velocity, makes the car move only to the direction it's facing
        Vector3 locVel = transform.InverseTransformDirection(rb.velocity);
        locVel = new Vector3(0, locVel.y, locVel.z);
        rb.velocity = transform.TransformDirection(locVel);
    }

    void Turn ()
    {
        // method for turning left and right
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-transform.up * turnSpeed * 10);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(transform.up * turnSpeed * 10);
        }
    }

    void Fall()
    {
        //adding a downforce for the object
        rb.AddForce(Vector3.down * gravityMultiplier * 10);
    }
}