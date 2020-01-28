using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage;
    public float force;

    public bool isAuto;
    public bool isSemi;
    public bool isBolt;

    public GameObject bulletPrefab;
    public Transform firingPoint;

    public shakeCamera cameraShakeScript;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        playerController.mana -= damage;

        CancelInvoke("AddMana");
        playerController.invokedAddingMana = false;

        // create bullet
        float bulletForce = force;
        GameObject bulletClone = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        Rigidbody2D bulletRB = bulletClone.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(firingPoint.up * bulletForce, ForceMode2D.Impulse);
        StartCoroutine(cameraShakeScript.Shake(0.1f, 0.05f));
    }
}