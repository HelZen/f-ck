﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayShield : MonoBehaviour
{
    public Text vitalText;
    public GameObject player;
    void Start()
    {
    }

    void Update()
    {
        playerController playerScript = player.gameObject.GetComponent<playerController>();
        vitalText.text = playerScript.shield.ToString();
    }
}
