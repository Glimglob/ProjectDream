using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float followDistanceStop;
    public Animator anim;
    public float moveX;
    public Vector2 relativePoint;
    public Transform enemy;
    public Transform player;
    public RaycastHit2D rch2d;
    public float dist = 1.0f;
    public Rigidbody2D rb2d;
    public Vector2 dir;
    public LayerMask playermask;
    public Vector2 origin;
    public bool left;
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.Find("player").transform;
        //anim = find
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, target.position) > followDistanceStop)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            moveX = 1;
            
        }
        anim.SetFloat("speed", Mathf.Abs(moveX));
        relativePoint = transform.InverseTransformPoint(player.position);
        if (relativePoint.x < 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
        {

            anim.SetBool("isLeft", true);
            left = true;
        }
        if (relativePoint.x > 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
        {

            anim.SetBool("isLeft", false);
            left = false;
        }
       if(left == true)
        {
            dir = Vector2.left;
        } else if(left == false)
        {
            dir = Vector2.right;
        }
       

    }
    void FixedUpdate()
    {
        //raycast
        Debug.DrawRay(origin, dir, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(origin, dir, dist, playermask);
        if (hit.collider != null)
        {
            Debug.Log("true");

        }

    }
}
