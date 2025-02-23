using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMove : MonoBehaviour
{
    [SerializeField]
    protected Enemy enemy;

    [SerializeField]
    protected Rigidbody2D body2D;

    protected void LimitTopSpeed()
    {
        if (body2D.velocity.magnitude > enemy.EnemyStats.MaxSpeed)
        {
            var velocity = body2D.velocity.normalized * enemy.EnemyStats.MaxSpeed;
            body2D.velocity = velocity;
        }
    }


    protected abstract void MoveEnemy(float amount, bool towardsPlayer);

    public abstract void KnockBack(float force);
}
