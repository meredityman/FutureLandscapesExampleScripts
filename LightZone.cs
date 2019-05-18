using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightZone : MonoBehaviour {
    public GameObject lightObject;

    Light ourLight;

	// Use this for initialization
	void Start () {
        ourLight = lightObject.GetComponent<Light>();

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ourLight.intensity = 8.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ourLight.intensity = 1.0f;
        }
    }
}
