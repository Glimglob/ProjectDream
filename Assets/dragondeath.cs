using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragondeath : MonoBehaviour
{
    public int dragonhealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dragonhealth == 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(int dam)
    {
        dragonhealth = dragonhealth - dam;
    }
}
