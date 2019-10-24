﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField]  public LayerMask pllayerMask;
    public float speed = 10;
    public Rigidbody2D rb;
    public float jumpVelocity;
    public CircleCollider2D rc2d;
    public float arrowSpeed = 10;
    //After the group has the sprite and a box collider is made, change Circlecollider2d to box collider and change every rc2d on script.


    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        rc2d = transform.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0;
        float moveY = 0;
        //Letter Movements
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
            moveY = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
            moveY = 0;
        }
        if (IsGrounded() && Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

        Vector3 moveDir = new Vector3(moveX, moveY);
        transform.position += moveDir * speed * Time.deltaTime;
        //Space Jump
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

        //Arrow Movements
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1;
            moveY = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1;
            moveY = 0;
        }
        if (IsGrounded() && Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
        HandleMovement();
    }
    private void HandleMovement()
    {
        
        //Arrow Movements
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(+arrowSpeed, rb.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-arrowSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

        }
    }
    
    private bool IsGrounded()
    {
        RaycastHit2D rch2d = Physics2D.BoxCast(rc2d.bounds.center, rc2d.bounds.size, 0, Vector2.down, 1, pllayerMask);
        return rch2d;
    }
}
        
    