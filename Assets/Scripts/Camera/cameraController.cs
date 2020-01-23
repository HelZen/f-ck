using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    void FixedUpdate()
    {
        Vector3 desiredPos = new Vector3 (player.position.x, player.position.y, -10);
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;
    }
}
