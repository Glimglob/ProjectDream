using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Rigidbody2D rb2d;
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
    //knockback
    public float knockbackY;
    public float knockbackX;
    public bool isLeft;
    public bool isKnockedBack;
    public bool isGrounded;

    void Start()
    {
        
        StartCoroutine(manaregen());
        rb2d = GetComponent<Rigidbody2D>();


    }
    void checkKnockback()
    {
        isKnockedBack = false;
        playerMovement PM = FindObjectOfType<playerMovement>();
        isGrounded = PM.isGrounded;
        if(isGrounded == false)
        {
            isKnockedBack = true;
        }
        

 
    }
    void Update()
    {
        checkKnockback();
        //import variables
        keyCounter = PlayerHealthbar.keyCounter;
        //Health and mana clamps
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        mana = Mathf.Clamp(mana, 0, 100);
        //death
        if (playerHealth == 0)
        {
            Destroy(gameObject);

        }
        


    }
    public void delog()
    {
        Debug.Log("This is working");
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
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "hitbox")
        {
            playerMovement PM = FindObjectOfType<playerMovement>();
            if (Input.GetKeyDown(KeyCode.P))
            {
                keyCounter++;
                    if (keyCounter == 1) {
                    if (PM.isLeft == false)
                    {
                        collision.GetComponentInParent<enemyDeath>().takeDamage(1, 200, 200);
                    }else if (PM.isLeft == true)
                    {
                        collision.GetComponentInParent<enemyDeath>().takeDamage(1, -200, 200);
                    }
                    }
                keyCounter--;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                keyCounter++;
                if (keyCounter == 1) 
                {
                    keyCounter--;
                    if (mana >= 30)
                    {
                        if (PM.isLeft == false)
                        {
                            collision.GetComponentInParent<enemyDeath>().takeDamage(3, 200, 200);
                        }
                        else if (PM.isLeft == true)
                        {
                            collision.GetComponentInParent<enemyDeath>().takeDamage(3, -200, 200);
                        }

                        mana = mana - 30;
                        Debug.Log(mana);
                    }
                    
                }
                
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement PM = FindObjectOfType<playerMovement>();
        isLeft = PM.isLeft;
        if(isLeft == true)
        {
            Debug.Log("isleft");
        }
        if (collision.tag == "enemy" && isKnockedBack == false)
        {
            rb2d.AddForce(transform.up * knockbackY);
            if (isLeft == true )
            {
                
                rb2d.AddForce(transform.right * (knockbackX));
            }
            else if (isLeft == false)
            {
                Debug.Log("isRight");
                rb2d.AddForce(transform.right * -(knockbackX));
            }
            

            takeDamage(10);
        }
    }
}

