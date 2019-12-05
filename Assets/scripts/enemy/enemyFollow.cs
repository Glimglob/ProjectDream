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
    public GameObject enemy;
    public Transform player;
    public RaycastHit2D rch2d;
    public float dist;

    // Start is called before the first frame update
    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        }
        if (relativePoint.x > 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
        {

            anim.SetBool("isLeft", false);
        }
        rch2d = Physics2D.Raycast(transform.position, transform.right, dist, 10 << 80);
        if(rch2d == true)
        {
            Debug.Log("hit");
        }
    }
}
