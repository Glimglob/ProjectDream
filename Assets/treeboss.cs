﻿using System.Collections;
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
        if (atkTimer <= 0)
        {
            StopCoroutine(lacornspawn());
            StopCoroutine(atkTimerDown());
            StartCoroutine(racornspawn());
            
        }

    }


    


    public void treeDamage(int dam)
    {
        treehealth = treehealth - dam;
    }
    IEnumerator atkTimerUp()
    {
        while (true)

        {
            atkTimer += 1;
                yield return new WaitForSeconds(1);
            if(atkTimer == 5)
            {
                StopCoroutine(atkTimerUp());
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
                    Instantiate(Acorn, leftAcorn.position, Quaternion.identity);
                    yield return new WaitForSeconds(1);
                    
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
            
            StartCoroutine(atkTimerUp());
                if (atkTimer <= 5)
                {
                    Instantiate(Acorn, leftAcorn.position, Quaternion.identity);
                    yield return new WaitForSeconds(1);
                    if (atkTimer >= 5)
                    {
                        StopCoroutine(atkTimerUp());
                        StartCoroutine(lacornspawn());

                    }
                }
                else
                {
                    yield return null;
                }
            }


        }
    }