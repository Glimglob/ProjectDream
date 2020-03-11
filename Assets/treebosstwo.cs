using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treebosstwo : MonoBehaviour
{
    public Transform leftAcorn;
    public Transform rightAcorn;
    public GameObject Acorn;
    public GameObject AcornR;
    public GameObject AcornUL;
    public GameObject AcornUR;
    public Transform endL;
    public Transform endR;
    public Transform endUR;
    public Transform endUL;
    public float acornCount;
    public Animator anim;
    public float timer;
    public float treehealth = 350;
    public portalLock PL;
    public playerCombat PC;
    public bool healthRevived;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("acornStart", 4);
        InvokeRepeating("acornleft", 5, 1);
        anim = GetComponent<Animator>();
        healthRevived = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(treehealth <= 0)
        {
            portalLock PL = FindObjectOfType<portalLock>();
            PL.unlock();
         
        }
        
    }
    public void treeDamage(int dam)
    {
        if (treehealth >= 200)
        {
            treehealth = treehealth - dam;
        }else if(treehealth <= 200)
        {
            print("use fire");
        }
       
    }
    
    public void treeBurning(int dam)
    {
        treehealth = treehealth - dam;
    }
    public void acornStart()
    {
        anim.SetBool("acorn Left", true);
    }
    public void acornSecond()
    {
        anim.SetBool("acorn Right", true);
    }
    public void acornleft()
    {
        

        Instantiate(Acorn, leftAcorn.position, Quaternion.identity);
        
        acornCount += 1;
        if(acornCount == 5)
        {
            CancelInvoke();
            anim.SetBool("acorn Left", false);
            anim.SetBool("look left", false);
            anim.SetBool("look right", true);
            if (treehealth >= 200)
            {
                Invoke("acornSecond", 4);
                InvokeRepeating("acornright", 5, 1);
            }else if(treehealth <= 200 && treehealth >= 1)
            {
                InvokeRepeating("treeburn", 2, 1);
            }
        }
    }
   public void acornright()
    {
       
        Instantiate(AcornR, rightAcorn.position, Quaternion.identity);
        acornCount -= 1;
        if(acornCount == 0)
        {
            CancelInvoke();
            anim.SetBool("acorn Right", false);
            anim.SetBool("look right", false);
            anim.SetBool("look left", true);
            if (treehealth >= 200)
            {
                Invoke("acornStart", 4);
                InvokeRepeating("acornleft", 5, 1);
            }
            else if (treehealth <= 200 && treehealth >= 1)
            {
                InvokeRepeating("treeburn", 1, 1);
            }
        }

    }
    public void treeburn()
    {
        if (healthRevived == false)
        {
            treehealth = 199;
            healthRevived = true;
        }
        anim.SetBool("burn1", true);
        if (treehealth >= 1)
        {
            InvokeRepeating("upAcorn", 3, 3);
            Instantiate(AcornR, endR.position, Quaternion.identity);
            Instantiate(Acorn, endL.position, Quaternion.identity);
            
        }
        if (treehealth <= 160 && treehealth >= 120)
        {
            anim.SetBool("burn1", false);
            anim.SetBool("burn2", true);
        }
        if (treehealth <= 120 && treehealth >= 80)
        {
            anim.SetBool("burn3", true);
        }
        if (treehealth <= 80 && treehealth >= 40)
        {
            anim.SetBool("burn4", true);
        }
        if (treehealth <= 40 && treehealth >= 0)
        {
            anim.SetBool("burn5", true);
        }
        if(treehealth <= 0)
        {
            anim.SetBool("zero", true);
            
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "fireball")
        {
            if(treehealth >= 200)
            {
                treeBurning(5);
            }
            if(treehealth <= 200)
            {
                treeBurning(20);
            }
            Destroy(collision.gameObject);
        }
    }
   public void upAcorn()
    {
        Instantiate(AcornUR, endUR.position, Quaternion.identity);
        Instantiate(AcornUL, endUL.position, Quaternion.identity);
        CancelInvoke("upAcorn");

    }
}
