using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public static int damage = 1;
    public static int playerHealth = 100;
    public static int mana = 100;
    public static int keyCounter;
    public PlayerHealthbar bars;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keyCounter = PlayerHealthbar.keyCounter;

    }
    public void delog()
    {
        Debug.Log("This is working");
    }
    public void Manadeplete()
    {
        keyCounter++;
        Debug.Log("This worked");
        if (keyCounter == 1)
        {
            mana = mana - 10;
            keyCounter--;
            Debug.Log(mana);
        }

    }
    public void Specialone()
    {
        if (mana >= 20)
        {
            keyCounter++;
            if (keyCounter == 1)
            {
                mana = mana - 20;
                keyCounter--;
                Debug.Log(mana);
                Debug.Log(keyCounter);
            }
        }
    }

}
