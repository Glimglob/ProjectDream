﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acornMove : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D rigidbody2d;
    public CircleCollider2D rc2d;
    public Animator anim;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        rc2d = transform.GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody2d.velocity = new Vector2(-speed, rigidbody2d.velocity.y);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<playerCombat>().takeDamage(20);
            anim.SetBool("Explode", true);
        }

    }
}

