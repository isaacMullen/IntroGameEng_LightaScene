using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    bool IsLightOn;

    Light flashLight;
    
    // Start is called before the first frame update
    void Start()
    {
        IsLightOn = false;
        flashLight = GetComponent<Light>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !IsLightOn)
        {
            flashLight.enabled = true;
            IsLightOn = true;
        }
        else if(Input.GetMouseButtonDown(0) && IsLightOn)
        {
            flashLight.enabled = false;
            IsLightOn = false;
        }
    }
}
