using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatforms : MonoBehaviour
{
    public float fallDelay = 2.0f;
    public Rigidbody2D rb2d;
    public float speed;
    public float time = 0;
    private void Update()
    {
        if (time >= 2)
        {
            rb2d.velocity = transform.up * speed;
            time = 0;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            rb2d.velocity = transform.up * -speed;
            timecount();
        }
    }
    void timecount()
    {
        time += Time.deltaTime;
        
    }

    
}
