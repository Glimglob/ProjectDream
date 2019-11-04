using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    //Variables
    public static int playerHealth = 100;
    public static int mana = 100;
    public static int keyCounter;
    public static int enemyhealth = 5;
    //hitbox variables
    public Transform attackPos;
    public float attackRangeX;
    public float attackRangeY;
    public LayerMask enemy;
    //health bar import
    public PlayerHealthbar bars;
    //fireball
    public Transform spawnPos;
    public GameObject fireballObj;
    //isdead
    public bool isdead;

    void Start()
    {
        StartCoroutine(manaregen());
    }
    private void Awake()
    {
        isdead = false;
    }
    void Update()
    {
        
        //import variables
        keyCounter = PlayerHealthbar.keyCounter;
        //Health and mana clamps
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        mana = Mathf.Clamp(mana, 0, 100);
        //death
        if (playerHealth == 0)
        {
            Destroy(gameObject);
            isdead = true;
        }
        playerMovement PM = FindObjectOfType<playerMovement>();


    }
    public void delog()
    {
        Debug.Log("This is working");
    }
    public void Manadeplete()
    {
        playerMovement PM = FindObjectOfType<playerMovement>();
        keyCounter++;
        Debug.Log("P is pressed");
        if (keyCounter == 1 && mana >= 10)
        {
            //hitbox
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, enemy);
            Collider2D[] leftenemy = Physics2D.OverlapBoxAll(-attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, enemy);
            if (PM.isLeft == false)
            {
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<enemyDeath>().takeDamage(1);
                }
            }else if (PM.isLeft == true)
            {
                for (int i = 0; i < leftenemy.Length; i++)
                {
                    leftenemy[i].GetComponent<enemyDeath>().takeDamage(1);
                }
            }
            //mana = mana - 10;
            keyCounter--;
            Debug.Log(mana);


        }

    }
    //draw hitbox
    private void OnDrawGizmosSelected()
    {
        playerMovement PM = FindObjectOfType<playerMovement>();
        Gizmos.color = Color.red;
        if(PM.isLeft == false)
        {
            Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
        }else if (PM.isLeft == true)
        {
            Gizmos.DrawWireCube(-attackPos.position, new Vector3(-attackRangeX, attackRangeY, 1));
        }
    }
    public void Specialone()
    {
        playerMovement PM = FindObjectOfType<playerMovement>();
        if (mana >= 20)
        {

            keyCounter++;
            if (keyCounter == 1)
            {

                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, enemy);
                Collider2D[] leftenemy = Physics2D.OverlapBoxAll(-attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, enemy);
                if (PM.isLeft == false)
                {
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<enemyDeath>().takeDamage(1);
                    }
                }
                else if (PM.isLeft == true)
                {
                    for (int i = 0; i < leftenemy.Length; i++)
                    {
                        leftenemy[i].GetComponent<enemyDeath>().takeDamage(1);
                    }
                }
                mana = mana - 20;
                keyCounter--;
                Debug.Log(mana);
                Debug.Log(keyCounter);
            }
        }
    }
    public void fireball()
    {
        if (mana >= 60)
        {
            keyCounter++;
            if (keyCounter == 1)
            {
                GameObject fire = Instantiate(fireballObj, transform.position, Quaternion.identity) as GameObject;
                mana -= 60;
                keyCounter--;
            }
        }
    }
    //manaregen
    IEnumerator manaregen()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log(mana);
            }
            if (mana < 100)
            {
                mana = mana + 5;
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return null;
            }
        }


    }
    public void takeDamage(int dam)
    {
        playerHealth = playerHealth - dam;
    }
    public void death()
    {
        
    }
}
