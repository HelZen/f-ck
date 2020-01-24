using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    Camera cam;

    public Transform firingPoint;
    public GameObject bulletPrefab;

    Vector2 movement;
    Vector2 mousePos;

    public float baseMoveSpeed = 5f;
        float moveSpeed;
        float sprintSpeed;
    public float baseHealth;
        float health;
    public float baseShield;
        float shield;
    public float baseStamina;
        float stamina;
    public float baseMana;
        float mana;

    public float baseMeleeDamage;
    public float baseMeleeCooldown;
    
    public float baseRangedDamage;
    public float baseRangedCooldown;

    public float baseMagicPower;
    public float baseMagicCost;
    public float baseMagicCooldown;

    void Awake()
    {
        rb = FindObjectOfType<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
    }

    void Start()
    {
        // set vitals
        health = baseHealth;
        shield = 0;
        stamina = baseStamina;
        mana = baseMana;

        moveSpeed = baseMoveSpeed;
        sprintSpeed = moveSpeed * 1.5f;
    }


    void Update()
    {

        // get input
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetButton("Sprint"))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = baseMoveSpeed;
        }

    }

    void FixedUpdate()

    {

        // move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

    void Shoot()
    {
        float bulletForce = 30f;
        GameObject bulletClone = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        Rigidbody2D bulletRB = bulletClone.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(firingPoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
