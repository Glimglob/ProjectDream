using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treebosstwo : MonoBehaviour
{
    public Transform leftAcorn;
    public Transform rightAcorn;
    public GameObject Acorn;
    public float acornCount;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("acornleft", 5, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(acornCount == 5)
        {
            CancelInvoke();
            bossSecond();
        }
        if(acornCount >= -5)
        {
            CancelInvoke();
            bossStart();
        }
    }
    void bossStart()
    {
        
    }
    void bossSecond()
    {
        InvokeRepeating("acornRight", 5, 1);
    }
    void acornleft()
    {
      Instantiate(Acorn, leftAcorn.position, Quaternion.identity);
        acornCount += 1;
    }
    void acornRight()
    {
        Instantiate(Acorn, rightAcorn.position, Quaternion.identity);
        acornCount -= 1;
    }
}
