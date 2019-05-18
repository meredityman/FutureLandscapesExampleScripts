using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UglyGuySpawner : MonoBehaviour {
    public int numberToSpawn;
    public GameObject[] uglyGuyPrefabs;
    public GameObject camera;

    Collider spawnArea;

	// Use this for initialization
	void Start () {
        spawnArea = GetComponent<Collider>();

        for(int i = 0; i < numberToSpawn; i++)
        {
            Vector3 min = spawnArea.bounds.min;
            Vector3 max = spawnArea.bounds.max;

            Vector3 pos = new Vector3(
                Random.Range(min.x, max.x),
                Random.Range(min.y, max.y),
                Random.Range(min.z, max.z)
                );



            GameObject uglyGuy = uglyGuyPrefabs[(int)(Random.Range(0, uglyGuyPrefabs.Length))];

            GameObject newUglyGuy = Instantiate(uglyGuy, pos, Quaternion.identity);
            newUglyGuy.transform.parent = this.transform;

            UglyMove uglyMove = newUglyGuy.GetComponent<UglyMove>();

            uglyMove.camera = this.camera;
            //uglyMove.speed = 0.07f;

        }

	}
	

}
