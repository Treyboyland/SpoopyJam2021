using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveUnitDistance : EnemyMove
{
    bool movementInterrupted;

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (!movementInterrupted)
        {
            MoveEnemy(enemy.EnemyStats.Speed * Time.fixedDeltaTime, true);
        }
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        movementInterrupted = false;
    }

    public override void KnockBack(float force)
    {
        if (gameObject.activeInHierarchy && enemy.EnemyStats.CanBeKnockedBack)
        {
            StopAllCoroutines();
            StartCoroutine(BeginKnockback(force));
        }
    }

    protected override void MoveEnemy(float amount, bool towardsPlayer)
    {
        if (Player.PlayerInstance == null || Player.PlayerInstance.IsDead)
        {
            //TODO: Also when player is dead?
            return;
        }

        Vector2 movementVector = (Player.PlayerInstance.transform.position - transform.position).normalized;
        movementVector *= towardsPlayer ? 1 : -1;

        body2D.MovePosition((Vector2)transform.position + (movementVector * amount));
    }

    IEnumerator BeginKnockback(float knockBack)
    {
        float elapsed = 0;
        movementInterrupted = true;

        while (elapsed < enemy.EnemyStats.KnockBackTime)
        {
            MoveEnemy(knockBack * Time.fixedDeltaTime, false);
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        movementInterrupted = false;
    }
}
