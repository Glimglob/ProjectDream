using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int health = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        //Add an && keydown x to see if that would work
        if(col.gameObject.tag == "Player")
        {
            health = health-1;
            Debug.Log("Health has reduced to: " + health);
            
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
