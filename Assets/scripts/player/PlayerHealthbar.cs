﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthbar : MonoBehaviour
{
    public static int playerHealth;
    public static int mana;
    public static int keyCounter;
    public playerCombat combat;
    void Start()
    {
        combat.delog();
        
    }
    public void FixedUpdate()
    {
        
        mana = playerCombat.mana;
        playerHealth = playerCombat.playerHealth;
        // bar transform
        Transform hBar = transform.Find("hBar");
        hBar.localScale = new Vector3(playerHealth * 2, 16f);
        Transform mBar = transform.Find("mBar");
        mBar.localScale = new Vector3(mana * 2, 16f);
        //Clamps
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        mana = Mathf.Clamp(mana, 0, 100);
    }

    // Update is called once per frame
    public void Update()
    { 

        if (Input.GetKeyDown(KeyCode.J))
        {
            combat.fireball();
        }
        

        
        
    }
   
    
}
