using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{
    public int health = 5;
    public GameObject enemy;
    public Rigidbody2D rb2d;
    public float knockbackX ;
    public float knockbackY;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = gameObject;
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void takeDamage(int dam, int forceX, int forceY)
    {
        rb2d.AddForce(transform.right * forceX);
        rb2d.AddForce(transform.up * forceY);
        health -= dam;
        print("damage taken" + dam);
        print(health);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            death();
        }
    }
    public bool isdead()
    {
        return health <= 0;
    }
    public void death()
    {
        Destroy(gameObject);
    }
}
