using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    EnemyDataSO dataSO;

    [SerializeField]
    EnemyMove movementScript;

    [SerializeField]
    GameEventGeneric<Vector3> onEnemyDefeated;

    [SerializeField]
    GameEvent onEnemyDamaged;

    uint health = 0;


    public EnemyDataSO EnemyStats { get => dataSO; }

    private void OnEnable()
    {
        health = dataSO.Health;
    }

    public void Damage(uint dmg)
    {
        //Debug.LogWarning("Damage " + dmg);
        if (dmg > health)
        {
            health = 0;
        }
        else
        {
            health -= dmg;
        }
        onEnemyDamaged.Invoke();

        if (health == 0)
        {
            onEnemyDefeated.Value = transform.position;
            onEnemyDefeated.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Damage(dataSO.Damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Damage(dataSO.Damage);
        }
    }

    public void KnockBack(float force)
    {
        if (dataSO.CanBeKnockedBack && movementScript != null)
        {
            movementScript.KnockBack(force);
        }
    }
}
