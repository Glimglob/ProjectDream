using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthBar : MonoBehaviour
{
    public int health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponentInParent<enemyDeath>().health;
    }

    // Update is called once per frame
    void Update()
    {
        health = GetComponentInParent<enemyDeath>().health;
        transform.localScale = new Vector3(health * 20, 10f);

    }
}
