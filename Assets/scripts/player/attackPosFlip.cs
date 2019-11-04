using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPosFlip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement PM = FindObjectOfType<playerMovement>();
        if(PM.isLeft == true)
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
