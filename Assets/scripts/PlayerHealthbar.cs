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
        hBar.localScale = new Vector3(playerHealth * 4, 35f);
        Transform mBar = transform.Find("mBar");
        mBar.localScale = new Vector3(mana * 4, 35f);
        //Clamps
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        mana = Mathf.Clamp(mana, 0, 100);
    }

    // Update is called once per frame
    public void Update()
    {
        
        //Regular skill
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            combat.Manadeplete();
        }
        
            
        


        // Special skills
        if (Input.GetKeyDown(KeyCode.X))
        {
            combat.Specialone();
        }
        
        // Health
        
        
    }
   
    
}
