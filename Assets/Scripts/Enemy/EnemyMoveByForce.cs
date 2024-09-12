using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveByForce : EnemyMove
{
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        MoveTowardsPlayer();
        LimitTopSpeed();
    }

    void MoveTowardsPlayer()
    {
        MoveEnemy(enemy.EnemyStats.ImpulseForce, true);
    }
}
