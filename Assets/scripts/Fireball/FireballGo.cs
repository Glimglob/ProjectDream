using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGo : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public CircleCollider2D cc2d;
    public static int enemyHealth;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        cc2d = transform.GetComponent<CircleCollider2D>();
        GameObject rEnemy = GameObject.Find("enemy");
        enemyHealth = playerCombat.enemyhealth;


    }

    // Update is called once per frame
    void Update()
    {
        this.rb.velocity = new Vector3(speed, 0, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name == "enemy")
        {

            Destroy(collision.gameObject);
        }
    }
}
