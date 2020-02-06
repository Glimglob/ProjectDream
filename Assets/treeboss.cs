using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeboss : MonoBehaviour
{
    //health
    public float treehealth = 500;

    //time
    public float atkTimer;

    //attacks
    public Transform leftAcorn;
    public Transform rightAcorn;
    public GameObject Acorn;
    public int aCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        atkTimer += Time.deltaTime;
        if(atkTimer >= 5)
        {
            lacornSpawn();
            atkTimer -= Time.deltaTime;
        }

    }

    
    public void racornSpawn()
    {

    }
    public void lacornSpawn()
    {
        if(atkTimer == 5)
        {
            Instantiate(Acorn, leftAcorn.position, transform.rotation);
        }
        if (atkTimer == 4)
        {
            Instantiate(Acorn, leftAcorn.position, transform.rotation);
        }
        if (atkTimer == 3)
        {
            Instantiate(Acorn, leftAcorn.position, transform.rotation);
        }
        if (atkTimer == 2)
        {
            Instantiate(Acorn, leftAcorn.position, transform.rotation);
        }
        if (atkTimer == 1)
        {
            Instantiate(Acorn, leftAcorn.position, transform.rotation);
        }


    }

    public void treeDamage(int dam)
    {
        treehealth = treehealth - dam;
    }
}
