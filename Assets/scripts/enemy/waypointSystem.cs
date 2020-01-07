using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class waypointSystem : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Animator anim;
    public Transform[] waypoints;
    private int randomSpot;
    public float moveX;
    public bool isleft;


    private void Start()
    {

        waitTime = startWaitTime;
        randomSpot = Random.Range(0, waypoints.Length);
        isleft = true;
    }
    private void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(moveX));
        transform.position = Vector2.MoveTowards(transform.position, waypoints[randomSpot].position, speed * Time.deltaTime);
        if(isleft == true)
        {
            anim.SetBool("isLeft", true);
        }
        if(Vector2.Distance(transform.position, waypoints[randomSpot].position)< 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, waypoints.Length);
                waitTime = startWaitTime;
                moveX = moveX + 1;
                



            }
            else
            {
                
                waitTime -= Time.deltaTime;
            }
        }
    }
}
