using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothing;
    public float RotationSmoothing;
    //player reference
    public Transform player;

    void FixedUpdate()
    {
        //follow the player
        transform.position =  Vector3.Lerp(transform.position, player.position, smoothing);
        // match the camera to the object's orientation
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, RotationSmoothing);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y,0));
    }
}
