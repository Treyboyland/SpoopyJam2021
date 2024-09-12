using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    protected Enemy enemy;

    [SerializeField]
    protected Rigidbody2D body2D;

    // Start is called before the first frame update
    void Start()
    {

    }

    protected void LimitTopSpeed()
    {
        if (body2D.velocity.magnitude > enemy.EnemyStats.MaxSpeed)
        {
            var velocity = body2D.velocity.normalized * enemy.EnemyStats.MaxSpeed;
            body2D.velocity = velocity;
        }
    }


    protected void MoveEnemy(float amount, bool towardsPlayer)
    {
        if (Player.PlayerInstance == null)
        {
            //TODO: Also when player is dead?
            return;
        }
        var playerPos = Player.PlayerInstance.transform.position;

        var movementVector = towardsPlayer ? (playerPos - transform.position).normalized
            : (transform.position - playerPos).normalized;

        body2D.AddForce(movementVector * amount, ForceMode2D.Impulse);
    }

    public void KnockBack(float force)
    {
        MoveEnemy(force, false);
    }
}
