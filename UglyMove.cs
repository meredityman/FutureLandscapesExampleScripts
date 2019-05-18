using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UglyMove : MonoBehaviour {

    public GameObject camera;

    public float speed;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 vector    = camera.transform.position - this.transform.position;
        Vector3 direction = vector.normalized;
        float  length     = vector.magnitude;

        rb.AddForce(direction * speed);

        transform.LookAt(camera.transform.position);

	}
}
