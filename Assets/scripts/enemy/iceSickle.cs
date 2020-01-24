using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceSickle : MonoBehaviour
{
    public BoxCollider2D bc2d;
    public Animator anim;
    public float time = 2;
    public float timeregen = 0;
    public bool iceSickleUp;
    void Start()
    {
        
    }
    private void Awake()
    {
        anim.SetBool("ready", false) ;
        iceSickleUp = false;
    }
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            bc2d.size = new Vector2(1,3);
            iceSickleUp = true;
                anim.SetBool("ready", true);
                timeregen += Time.deltaTime;
                if (timeregen >= 2)
                {
                bc2d.size = new Vector2(1, 1);
                time = 2;
                    anim.SetBool("ready", false);
                iceSickleUp = false;
                }
            
        }
        if(time >= 0)
        {
            timeregen = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "fireball")
        {
            gameObject.SetActive(false);
        }
    }
}
