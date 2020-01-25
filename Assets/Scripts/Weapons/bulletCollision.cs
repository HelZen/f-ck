﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    GameObject[] player;


    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyController>().hp -= Convert.ToInt32(player[0].gameObject.GetComponent<playerController>().baseRangedDamage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
