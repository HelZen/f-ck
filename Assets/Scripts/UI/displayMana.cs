using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayMana : MonoBehaviour
{
    public Text vitalText;
    void Start()
    {
    }

    void Update()
    {
        vitalText.text = playerController.mana.ToString();
    }
}
