using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyAI : MonoBehaviour
{
    public AIPath aiPath;
    public SpriteRenderer enemy;

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            enemy.flipX = true;
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            enemy.flipX = false;
        }
    }
}
