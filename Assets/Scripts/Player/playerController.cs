using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerController : MonoBehaviour
{
    Rigidbody2D rb;

    Camera cam;
    public shakeCamera cameraShakeScript;
    
    Vector2 movement;
    Vector2 mousePos;

    public float baseMoveSpeed = 5.0f;
    float moveSpeed;
    float sprintSpeed;
    
    public float health;
    float maxHealth;
    
    public float shield;
    float maxShield;
    
    public float mana;
    float maxMana;
    bool invokedAddingMana = false;

    public Transform firingPoint;
    public GameObject bulletPrefab;


    public int stamina;
    int maxStamina;
    
    public int baseRangedDamage;
    public int baseRangedCost;
    
    public float baseRangedCooldown;
    public float damageCooldown;

    bool godLike = false;

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();

    }
    void Start()
    {

        // set vitals
        maxHealth = health;
        maxShield = shield;
        maxStamina = stamina;
        maxMana = mana;

        if (health == 0)
        {
            maxHealth = 100;
            health = 100;
        }

        if (shield == 0)
        {
            maxShield = 100;
            shield = 0;
        }

        if (mana == 0)
        {
            maxMana = 100;
            mana = 100;
        }

        // set default values
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
        
        // fire weapon
        if (mana >= baseRangedCost)
        {
        
            if (Input.GetButtonDown("Fire1"))
            {
            
                Shoot();
            
            }

        }
        
        // sprint
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

        // make shield and mana stay above 0 and below 100
        shield = Mathf.RoundToInt(Mathf.Clamp(shield, 0.0f, 100.0f));
        mana = Mathf.RoundToInt(Mathf.Clamp(mana, 0.0f, 100.0f));
        
        // add mana points over time
        if (mana < 100 && invokedAddingMana == false)
        {

            InvokeRepeating("AddMana", 1.25f, 0.25f);
            invokedAddingMana = true;

        }
        else if (mana == 100)
        {
            CancelInvoke("AddMana");
            invokedAddingMana = false;
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            hesoyam();
        }

        
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            godLike = true; // max everything forever
        }
        if (godLike)
        {
            mana = maxMana;
            health = maxHealth;
            shield = maxShield;
        }

    }
    void FixedUpdate()
    {

        // move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //rotate player based on position of mouse
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90.0f;
        rb.rotation = angle;

    }
    void Shoot()
    {

        mana -= baseRangedCost;
        
        CancelInvoke("AddMana");
        invokedAddingMana = false;
        
        // create bullet
        float bulletForce = 30f;
        GameObject bulletClone = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        Rigidbody2D bulletRB = bulletClone.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(firingPoint.up * bulletForce, ForceMode2D.Impulse);
        StartCoroutine(cameraShakeScript.Shake(0.1f, 0.05f));
    }
    void AddMana()
    {
        mana += 10;
    }

    void hesoyam() // give max everything, the script name is a reference to a cheat code in GTA: SA
    {
        mana = maxMana;
        health = maxHealth;
        shield = maxShield;
    }
}
