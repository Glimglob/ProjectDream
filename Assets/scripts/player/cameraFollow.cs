using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public bool isdead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCombat PC = FindObjectOfType<playerCombat>();
        if (PC.isdead == false)
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
        }
        else  
        {
            Debug.Log("dead");
        }

    }
}
