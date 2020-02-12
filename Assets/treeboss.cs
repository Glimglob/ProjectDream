using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeboss : MonoBehaviour
{
    //health
    public float treehealth = 500;

    //time
    public float atkTimer;

    //attacks
    public Transform leftAcorn;
    public Transform rightAcorn;
    public GameObject Acorn;
    public int aCount = 1;
    void Start()
    {
        StartCoroutine(atkTimerUp());
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    


    public void treeDamage(int dam)
    {
        treehealth = treehealth - dam;
    }
    public void restartTime()
    {
        StartCoroutine(atkTimerUp());
    }
    IEnumerator atkTimerUp()
    {
        while (true)

        {
            atkTimer += 1;
                yield return new WaitForSeconds(1);
            if(atkTimer == 5)
            {
                StopAllCoroutines();
                StartCoroutine(lacornspawn());
                
            }

        }

    }
    IEnumerator atkTimerUpCont()
    {
        while (true)
        {
            if (atkTimer == 0)
            {
                atkTimer += 1;
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return null;
            }

        }

    }
    IEnumerator atkTimerDown()
    {
        while (true)
        {
            
                atkTimer -= 1;
                yield return new WaitForSeconds(1);
                if(atkTimer <= 0)
                {
                StartCoroutine(racornspawn());
                StopCoroutine(lacornspawn());
                StopCoroutine(atkTimerDown());
                 }else
            {
                yield return null;
            }
            


        }
    }
        IEnumerator lacornspawn()
        {
            while (true)
            {
                StartCoroutine(atkTimerDown());
                if (atkTimer >= 0)
                {
                yield return new WaitForSeconds(1);
                Instantiate(Acorn, leftAcorn.position, Quaternion.identity);
                    
                    if(atkTimer == 0)
                    {
                    StopAllCoroutines();
                    StartCoroutine(racornspawn());
                    }
                }
                else
                {
                    yield return null;
                }
            }


        }
        IEnumerator racornspawn()
        {
            while (true)
            {

            StartCoroutine(atkTimerDown());
                if (atkTimer <= 0)
                {
                    Instantiate(Acorn, rightAcorn.position, Quaternion.identity);
                    yield return new WaitForSeconds(1);
                    if (atkTimer <= -5)
                    {
                        StopAllCoroutines();
                        restartTime();

                    }
                }
                else
                {
                    yield return null;
                }
            }


        }
    }
