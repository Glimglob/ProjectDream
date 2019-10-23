using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGo : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public CircleCollider2D cc2d;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        cc2d = transform.GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        this.rb.velocity = new Vector3(speed, 0, 0);
    
    }
     void OnCollisionEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "enemy")
        {
            Debug.Log("jhdfjhjhdfjhefjhdfjhhdjhd");
        }
    }
}
