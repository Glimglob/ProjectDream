using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treebosstwo : MonoBehaviour
{
    public Transform leftAcorn;
    public Transform rightAcorn;
    public GameObject Acorn;
    public GameObject AcornR;
    public float acornCount;
    public Animator anim;
    public float timer;
    public float treehealth = 350;
    public portalLock PL;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("acornStart", 4);
        InvokeRepeating("acornleft", 5, 1);
        anim = GetComponent<Animator>();
        
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
            Invoke("acornSecond", 4);
            InvokeRepeating("acornright", 5, 1);
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
            Invoke("acornStart", 4);
            InvokeRepeating("acornleft", 5, 1);
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

}
