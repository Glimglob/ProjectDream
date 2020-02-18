using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    void Update()
    {
        if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-10f, 1f, 10f);
        } else if (aiPath.desiredVelocity.x >= -0.01f)
        {
            transform.localScale = new Vector3(10f, 1f, 10f);
        }
    }
}
