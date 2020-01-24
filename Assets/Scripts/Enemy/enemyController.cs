using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float baseHP;
    public float hp;
    public float baseSpeed;
    float speed;
    public float baseDamage;

    void Start()
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
        if (collision.gameObject.tag == "Player")
        {
            playerController player  = collision.gameObject.GetComponent<playerController>();
            if (player.damageCooldown <= 0)
            {
                player.health -= baseDamage;
                player.damageCooldown = 0.5f;
            }

        }
    }

}
