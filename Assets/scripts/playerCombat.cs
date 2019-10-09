using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public static int damage = 1;
    public static int playerHealth = 100;
    public static int mana = 100;
    public static int keyCounter;
    public static int enemyhealth = 5;
    public Transform attackPos;
    public float attackRange;
    public LayerMask enemy;
    public PlayerHealthbar bars;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        keyCounter = PlayerHealthbar.keyCounter;
        enemyhealth = enemyHealth.health;
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        mana = Mathf.Clamp(mana, 0, 100);
        if (playerHealth == 0)
        {
            Destroy(gameObject);
        }
    }
    public void delog()
    {
        Debug.Log("This is working");
    }
    public void Manadeplete()
    {
        keyCounter++;
        Debug.Log("This worked");
        if (keyCounter == 1 && mana >= 10)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemyhealth = enemyhealth - damage;
            }
                
                mana = mana - 10;
                keyCounter--;
                Debug.Log(mana);
            
            
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    public void Specialone()
    {
        if (mana >= 20)
        {
            keyCounter++;
            if (keyCounter == 1)
            {
                
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    damage = 2;
                    enemyhealth = enemyhealth - damage;
                    
                }
                mana = mana - 20;
                keyCounter--;
                Debug.Log(mana);
                Debug.Log(keyCounter);
            }
        }
    }
    public void death()
    {
        
    }
   

}
