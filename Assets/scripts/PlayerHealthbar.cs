using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthbar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform hBar = transform.Find("hBar");
        hBar.localScale = new Vector3(250f, 35f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
