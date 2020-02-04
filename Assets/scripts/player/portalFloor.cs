using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalFloor : MonoBehaviour
{
    public Transform destination;
    public Transform player;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rb = collision.GetComponent<Rigidbody2D>();
            player.transform.position = destination.position;
            rb.Sleep();
        }

    }
}
