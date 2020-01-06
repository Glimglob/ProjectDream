using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class waypointSystem : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] waypoints;
    private int randomSpot;

    private void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, waypoints.Length);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[randomSpot].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, waypoints[randomSpot].position)< 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, waypoints.Length);
                waitTime = startWaitTime;

            }
            else
            {
                waitTime -= Time.deltaTime;            }
        }
    }
}
