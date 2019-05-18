using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDim : MonoBehaviour {

    bool isDimming;

    public void OnLightDim()
    {
        Debug.Log("Hi, I should be dimming");

        if (!isDimming)
        {
            StartCoroutine(DimLight());
        }        
    }

    IEnumerator DimLight()
    {
        isDimming = true;
        Light light = GetComponent<Light>();
        light.intensity = 20.0f;

        while(light.intensity > 1.0f)
        {
            light.intensity -= 0.01f;

            yield return new WaitForEndOfFrame();
        }
        isDimming = false;
    }
}
