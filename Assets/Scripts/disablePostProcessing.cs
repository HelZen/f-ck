using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class disablePostProcessing : MonoBehaviour
{
    public PostProcessVolume ppv;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) && ppv.enabled == true)
        {
            ppv.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.F1) && ppv.enabled == false)
        {
            ppv.enabled = true;
        }
    }
}
