using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScream : MonoBehaviour {
    AudioSource screamAudio;

	// Use this for initialization
	void Start () {
        screamAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if(collision.collider.tag == "Player")
        {
            screamAudio.Play();
        }        
    }
}
