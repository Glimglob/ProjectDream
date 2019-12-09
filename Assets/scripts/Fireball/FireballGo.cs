using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGo : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public CircleCollider2D cc2d;
    public int lifelimit;
    
 

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        cc2d = transform.GetComponent<CircleCollider2D>();
        StartCoroutine(lifelimitdead());
        


    }

    // Update is called once per frame
    void Update()
    {
        playerMovement PM = FindObjectOfType<playerMovement>();
        if (PM.isLeft == false)
        {
            this.rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (PM.isLeft == true)
        {
            this.rb.velocity = new Vector3(-speed, 0, 0);
        }
        if(lifelimit == 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement PM = FindObjectOfType<playerMovement>();
        if (collision.tag == "enemy")
        {
            if (PM.isLeft == false)
            {
                collision.GetComponent<enemyDeath>().takeDamage(4, 300, 300);
            }
            if (PM.isLeft == true)
            {
                collision.GetComponent<enemyDeath>().takeDamage(4, -300, 300);
            }
            Destroy(gameObject);
        }
    }
    IEnumerator lifelimitdead()
    {
        while (true)
        {
            lifelimit = 0;
            lifelimit = lifelimit + 1;
            
        }


    }
}
