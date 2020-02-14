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
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("acornleft", 5, 1);
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        
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
            InvokeRepeating("acornright", 5, 1);
        }
    }
   public void acornright()
    {
        anim.SetBool("acorn Right", true);
        Instantiate(AcornR, rightAcorn.position, Quaternion.identity);
        acornCount -= 1;
        if(acornCount == 0)
        {
            CancelInvoke();
            anim.SetBool("acorn Right", false);
            anim.SetBool("look right", false);
            anim.SetBool("look left", true);
            InvokeRepeating("acornleft", 5, 1);
        }

    }
    
}
