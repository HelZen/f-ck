using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            // collision.enemyController.hp -= playerController.baseDamage;
        }

        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
