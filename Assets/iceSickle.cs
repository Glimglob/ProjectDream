using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceSickle : MonoBehaviour
{
    public BoxCollider2D bc2d;
    public Animator anim;
    public float time = 2;
    public float timeregen = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            
                anim.SetBool("ready", true);
                timeregen += Time.deltaTime;
                if (timeregen >= 2)
                {
                    time = 2;
                    anim.SetBool("ready", false);
                }
            
        }
        if(time >= 0)
        {
            timeregen = 0;
        }
    }
   
}
