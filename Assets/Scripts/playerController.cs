using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;
    public float sprintSpeed;

    public float baseHealth;
    public float baseShield;
    public float baseStamina;
    public float baseMana;

    public float baseMeleeDamage;
    public float baseMeleeCooldown;
    
    public float baseRangedDamage;
    public float baseRangedCooldown;

    public float baseMagicPower;
    public float baseMagicCost;
    public float baseMagicCooldown;

    public string[] meleeWeaponsList;
    public string[] rangedWeaponsList;

    private void Awake()
    {
    
        //rangedWeaponsList = {
        //    "Bow",
        //    -1
        //};

    }

    void Start()
    {
    

    
    }

    void Update()
    {



    }

    void FixedUpdate()
    {
    
        

    }

}
