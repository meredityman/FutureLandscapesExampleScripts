using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class SpiderMove : MonoBehaviour {


    Rigidbody rigidBody;
    Vector3 direction;
    Vector3 deltaDirection;


    Vector3 directionOffset;
    int motionSeedIndex;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        direction   = Random.onUnitSphere;

        directionOffset = Random.onUnitSphere;
        motionSeedIndex = Random.Range(0, MotionSeed.numVectors);
    }
	
	// Update is called once per frame
	void Update () {

        if(rigidBody.velocity.y == 0.0f && rigidBody.velocity.magnitude < MotionSeed.maxSpeed)
        {
            //rigidBody.SimpleMove(direction * speed);
            rigidBody.AddForce(direction * MotionSeed.speed, ForceMode.Impulse);

            deltaDirection = (MotionSeed.GetDeltaDirection(motionSeedIndex) + directionOffset) * 360.0f * MotionSeed.scuttliness;
            direction = Quaternion.Euler(deltaDirection) * direction;
        }



    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawRay( transform.position, transform.position * rigidBody.)
    }
}
