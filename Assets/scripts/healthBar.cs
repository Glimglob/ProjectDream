using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public static int health;
    public SpriteRenderer rend;
    public Sprite health5, health4, health3, health2, health1;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        health5 = Resources.Load<Sprite>("Health bar_0");
        health4 = Resources.Load<Sprite>("Health bar test");
        health3 = Resources.Load<Sprite>("Health bar_2");
        health2 = Resources.Load<Sprite>("Health bar_3");
        health1 = Resources.Load<Sprite>("Health bar_4");
    }

    // Update is called once per frame
    void Update()
    {
        health = enemyHealth.health;
        if(health == 4)
        {
            rend.sprite = health4;
        }
    }
}
