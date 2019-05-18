using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

    public GameObject prefab;
    public int number;

	// Use this for initialization
	void Start () {
		 for( int i = 0; i < number; i++)
         {
            Vector3 position = new Vector3(
                    transform.position.x + Random.Range(-10f, 10f),
                    transform.position.y + Random.Range(-10f, 10f),
                    transform.position.z + Random.Range(-10f, 10f)                
                );

            Instantiate(prefab, position, Random.rotation);
         }
	}

}
