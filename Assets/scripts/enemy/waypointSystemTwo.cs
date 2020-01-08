using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointSystemTwo : MonoBehaviour
{
    public float actualSpeed = 10.0f;
    public Transform[] checkpoints;
    public int counter = 0;
    public Animator anim;
    public float distance = 2.0f; 
    private static Vector3 direction;

    void FixedUpdate()
    {
        
        Vector3 dir = direction;
        direction = Vector3.zero;
        
        direction = checkpoints[counter].transform.position - transform.position;
        //distance
        if (direction.magnitude < distance)
        {
            if (counter < checkpoints.Length - 1) //switch to the next waypoint 
            {
                counter++;
            }
            else //reset counter
           {
                counter = 0;
            }
        }
        direction = direction.normalized;


        transform.position = Vector2.MoveTowards(transform.position, checkpoints[counter].position, actualSpeed * Time.deltaTime);
        
    }
    private void Update()
    {
        //animations
        anim.SetFloat("speed", Mathf.Abs(actualSpeed));
        if (counter == 1)
        {
            anim.SetBool("isLeft", false);
        }
        else
        {
            anim.SetBool("isLeft", true);
        }
    }
}
