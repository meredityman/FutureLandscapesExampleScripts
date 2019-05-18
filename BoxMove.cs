using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour {
    float offset;
    // Use this for initialization
    void Start () {
        offset = Random.value * 2.0f * Mathf.PI;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Update");
        transform.Translate(  new Vector3(0.0f, 0.1f, 0.0f) * Mathf.Sin( Time.time * 10f + offset) );

        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();

        Material cubeMaterial = meshRenderer.material;

        cubeMaterial.color = new Color(
                0.5f + 0.5f * Mathf.Sin(Time.time * 0.3f + offset), 
                0.5f + 0.5f * Mathf.Cos(Time.time * 0.7f + offset), 
                0.5f + 0.5f * Mathf.Sin(Time.time * 0.1f + offset) );
    }
}
