using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public CircleCollider2D cc2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        cc2d = transform.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerCombat pc = FindObjectOfType<playerCombat>();
            pc.takeDamage(10);
        }
    }
}
