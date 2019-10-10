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
    public float attackRangeX;
    public float attackRangeY;
    public LayerMask enemy;
    public PlayerHealthbar bars;

    void Start()
    {
        StartCoroutine(manaregen());
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
        Debug.Log("P is pressed");
        if (keyCounter == 1 && mana >= 10)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, enemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemyhealth -= 1;
            }

            //mana = mana - 10;
            keyCounter--;
            Debug.Log(mana);


        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
    public void Specialone()
    {
        if (mana >= 20)
        {

            keyCounter++;
            if (keyCounter == 1)
            {

                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, enemy);
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
}
