using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    public float health;
    float maxHealth;

    public float shield;
    float maxShield;
    
    public float stamina;
    float maxStamina;
    
    public float mana;
    float maxMana;

    public float baseMeleeDamage;
    public float baseMeleeCooldown;
    
    public float baseRangedDamage;
    public float baseRangedCooldown;

    public float baseMagicPower;
    public float baseMagicCost;
    public float baseMagicCooldown;

    public float damageCooldown;
    void Awake()
    {
        rb = FindObjectOfType<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
    }

    void Start()
    {
        // set vitals
        maxHealth = health;
        maxShield = shield;
        maxStamina = stamina;
        maxMana = mana;

        damageCooldown = 0;

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

        if (damageCooldown > 0)
        {
            damageCooldown -= Time.deltaTime;
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
