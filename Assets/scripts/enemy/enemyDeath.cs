using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{
    public int health = 5;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = gameObject;
    }
    public void takeDamage(int dam)
    {
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
