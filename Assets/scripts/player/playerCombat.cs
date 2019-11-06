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
        
        keyCounter++;
        Debug.Log("P is pressed");
        if (keyCounter == 1 && mana >= 10)
        {
            EnemyHitBox HB = FindObjectOfType<EnemyHitBox>();
            HB.attackone();

            keyCounter--;
            Debug.Log(mana);


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
                EnemyHitBox HB = FindObjectOfType<EnemyHitBox>();
                HB.specialone();


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
