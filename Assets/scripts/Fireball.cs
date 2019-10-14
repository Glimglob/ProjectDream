using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Rigidbody2D rb;
    public playerCombat combat;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        throw = combat.spawnPos;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
