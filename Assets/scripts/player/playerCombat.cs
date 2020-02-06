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
    public float timeDamTaken;
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
    public float knockbackYI;
    public float knockbackXI;
    public bool isLeft;
    public bool isKnockedBack;
    public bool isGrounded;
    //respawn
    public Transform SpawnPoint;
    //ice sickle
    public bool iceSickleUp;
    //falling platform
    public int FPnum;

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
        playerMovement PM = FindObjectOfType<playerMovement>();
        isLeft = PM.isLeft;
        
        checkKnockback();
        //import variables
        keyCounter = PlayerHealthbar.keyCounter;
        //Health and mana clamps
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        mana = Mathf.Clamp(mana, 0, 100);
        //death
        if (playerHealth <= 0)
        {
            playerHealth = 100;
            mana = 100;
            gameObject.transform.position = SpawnPoint.position;
            rb2d.velocity = Vector3.zero;
            rb2d.Sleep();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            gameObject.transform.position = SpawnPoint.position;
            rb2d.velocity = Vector3.zero;
            rb2d.Sleep();
            if(FPnum >= 0)
            {
                FindObjectOfType<fellplat>().GetPlatformBack();
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            fireball();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(mana == 100)
            {
                playerHealth += 33;
                mana -= 100;
            }
        }



    }
    public void delog()
    {
        Debug.Log("This is working");
    }
    

    
    public void fireball()
    {
        if (mana >= 50)
        {
            keyCounter++;
            if (keyCounter == 1)
            {
                GameObject fire = Instantiate(fireballObj, transform.position, Quaternion.identity) as GameObject;
                mana -= 50;
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
                mana = mana + 10;
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
    IEnumerator icesickledam()
    {
        
        while (true)
        {
            if(playerHealth >= 1)
            {
                playerHealth = playerHealth - 1;
                timeDamTaken += 1;
                yield return new WaitForSeconds(1);
                if(timeDamTaken == 5)
                {
                    yield return null;
                }
            }
            else
            {
                yield return null;
            }
        }


    }
    public void OnTriggerStay2D(Collider2D collision)
    { 
    {
        if (collision.tag == "hitbox")
        {
            playerMovement PM = FindObjectOfType<playerMovement>();
            
            if (Input.GetMouseButtonDown(0))
            {
                keyCounter++;
                if (keyCounter == 1) 
                {
                    keyCounter--;
                        if (PM.isLeft == false)
                        {
                            collision.GetComponentInParent<enemyDeath>().takeDamage(1, 200, 200);
                        }
                        else if (PM.isLeft == true)
                        {
                            collision.GetComponentInParent<enemyDeath>().takeDamage(1, -200, 200);
                        }

                        
                        
                    }
                    
                }
                
            }
        if (collision.tag == "icesickle")
            {
                takeDamage(10);
            }
        }
        if(collision.tag == "bosshitbox")
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                keyCounter++;
                if(keyCounter == 1)
                {
                    collision.GetComponentInParent<treeboss>().treeDamage(1);
                }

            }
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
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
        if(collision.tag == "icesickle")
        {
            iceSickleUp = collision.GetComponent<iceSickle>().iceSickleUp;
            rb2d.AddForce(transform.up * knockbackYI);
            if (isLeft == true)
            {

                rb2d.AddForce(transform.right * -(knockbackXI));
            }
            else if (isLeft == false)
            {
                Debug.Log("isRight");
                rb2d.AddForce(transform.right * (knockbackXI));
            }
            if(iceSickleUp == true)
            {
                takeDamage(100);
            }else if(iceSickleUp == false)
            {
                takeDamage(5);
            }
        }
    }
}

