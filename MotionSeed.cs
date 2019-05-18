using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSeed : MonoBehaviour {
    public static int numVectors = 10;
    public float changeRate = 0.2f;

    public static float speed = 5.0f;
    public static float scuttliness = 0.5f;
    public static float maxSpeed = 0.5f;

    private static MotionSeed instance;
    public static Vector3 GetDeltaDirection(int num)
    {
        return instance.currentVector[num];
    }

    Vector3[] currentVector;

	// Use this for initialization
	void Start () {
        if (instance == null) instance = this;
        currentVector = new Vector3[numVectors];

    }
	
	// Update is called once per frame
	void Update () {
		
        for( int i = 0; i < numVectors; i++)
        {
            currentVector[i] = new Vector3(
                    Mathf.PerlinNoise(i, changeRate * Time.time),
                    Mathf.PerlinNoise(i, changeRate * Time.time + 1.0f),
                    Mathf.PerlinNoise(i, changeRate * Time.time + 2.0f)
                );
        }    
	}
}
