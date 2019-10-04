using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthbar : MonoBehaviour
{
    public int playerHealth = 100;
    public int mana = 100;
    public int keyCounter;
    void Start()
    {
        
    }
    
    // Update is called once per frame
    private void Update()
    {
        //Clamps
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        mana = Mathf.Clamp(mana, 0, 100);
        //Regular skill
        if (Input.GetKeyDown(KeyCode.P))
        {
            keyCounter++;
            manadeplete();
        }
        // Special skills
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(mana >= 20)
            {
                keyCounter++;
                if(keyCounter == 1)
                {
                    mana = mana - 20;
                    keyCounter--;
                }
            }
        }
        // bar transform
        Transform hBar = transform.Find("hBar");
        hBar.localScale = new Vector3(playerHealth * 4, 35f);
        Transform mBar = transform.Find("mBar");
        mBar.localScale = new Vector3(mana * 4, 35f);
        
    }
    //Regular mana deplete
    void manadeplete()
    {
        if (keyCounter == 1)
        {
            mana = mana - 10;
            keyCounter--;
        }
        
    }
}
