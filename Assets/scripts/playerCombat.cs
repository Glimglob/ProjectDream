using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public static int damage = 1;
    public static int playerHealth;
    public PlayerHealthbar bars;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = PlayerHealthbar.playerHealth;
        if(playerHealth == 0)
        {
            Destroy(gameObject);
        }
    }
    
}
