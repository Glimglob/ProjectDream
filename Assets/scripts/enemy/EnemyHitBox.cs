using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{

    public Transform hitBox;
    public float RangeX;
    public float RangeY;
    public LayerMask player;
    public GameObject enemy;
    public int keyCounter;
    public int mana;
    // Start is called before the first frame update
    void Start()
    {
        keyCounter = PlayerHealthbar.keyCounter;
        mana = playerCombat.mana;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void attackone()
    {
        keyCounter++;
        Debug.Log("P is pressed");
        if (keyCounter == 1 && mana >= 10)
        { 
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(hitBox.position, new Vector2(RangeX, RangeY), 0, player);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                this.gameObject.GetComponent<enemyDeath>().takeDamage(1);
            }
        }
    }
    public void specialone()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            


            if (mana >= 20)
            {

                keyCounter++;
                if (keyCounter == 1)
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(hitBox.position, new Vector2(RangeX, RangeY), 0, player);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        this.gameObject.GetComponent<enemyDeath>().takeDamage(1);
                    }
                    mana = mana - 20;
                    keyCounter--;
                    Debug.Log(mana);
                    Debug.Log(keyCounter);
                }
            }
        }
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(hitBox.position, new Vector3(RangeX, RangeY, 1));
    }
}
