using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public static float time = 25;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            timeloop(); ;
        }
    }
    public void timeloop()
    {
        Debug.Log("dead");
        playerCombat.playerHealth = 100;
        playerCombat.mana = 100;
        SceneManager.LoadScene("Jiro Area 2-1");
        time = 25;
    }
}
