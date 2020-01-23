using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootShake : MonoBehaviour
{
    public shakeCamera cameraShake;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(cameraShake.Shake(.1f, .05f));
        }
    }
}
