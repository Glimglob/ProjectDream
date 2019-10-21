using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShoot : MonoBehaviour
{
    public float moveSpeed;
    private float maxSpeed = 5f;
    private Vector3 input;
    public GameObject fireballObj;
    public float force;

    void Start()
    {

    }

    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (GetComponent<Rigidbody2D>().velocity.magnitude < maxSpeed)
        {
            GetComponent<Rigidbody2D>().AddForce(input * moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject bullet = Instantiate(fireballObj, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * force, ForceMode2D.Force);
        }

        print(input);
    }
}
