using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    public int baseHP;
    public int hp;
    public float baseSpeed;
    float speed;
    public int baseDamage;

    void Awake()
    {

        hp = baseHP;
        speed = baseSpeed;
    
    }

    void Update()
    {

        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player") // damage player if they collide
        {
        
            playerController player  = collision.gameObject.GetComponent<playerController>();
            
            if (player.damageCooldown <= 0.0f)
            {
            
                if (player.shield <= 0)
                {
                
                    player.health -= baseDamage;
                    player.damageCooldown = 0.5f;
                
                }
                else
                {
                
                    player.shield -= baseDamage;
                    player.damageCooldown = 0.5f;
                
                }
            
            }

        }
    }

}
