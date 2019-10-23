using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{

    public static int health;
    public static int damage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        health = playerCombat.enemyhealth;
        damage = playerCombat.damage;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
