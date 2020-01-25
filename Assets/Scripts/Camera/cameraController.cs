using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public float fixedRotation = 5.0f;
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, fixedRotation, transform.eulerAngles.z);
        Vector3 desiredPos = new Vector3 (player.localPosition.x - 1.0f, player.localPosition.y, -10.0f);
        Vector3 smoothedPos = Vector3.Lerp(transform.localPosition, desiredPos, smoothSpeed);
        transform.localPosition = smoothedPos;
    }
}
