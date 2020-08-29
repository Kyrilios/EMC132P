using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    // public variables for easy access
        public PathCreator pathCreator;
        public float speed;
        float distanceTravelled;

    void FixedUpdate()
    {
        //acceleration of the object
        distanceTravelled += speed * Time.deltaTime;
        //alligns and positions the object to the path
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        //corrects the object's orientation
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}
