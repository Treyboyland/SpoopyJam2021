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
        MoveEnemy(enemy.EnemyStats.Speed, true);
    }

    public override void KnockBack(float force)
    {
        MoveEnemy(force, false);
    }

    protected override void MoveEnemy(float amount, bool towardsPlayer)
    {
        if (Player.PlayerInstance == null || Player.PlayerInstance.IsDead)
        {
            //TODO: Also when player is dead?
            return;
        }
        var playerPos = Player.PlayerInstance.transform.position;

        var movementVector = towardsPlayer ? (playerPos - transform.position).normalized
            : (transform.position - playerPos).normalized;

        body2D.AddForce(movementVector * amount, ForceMode2D.Impulse);
    }
}
