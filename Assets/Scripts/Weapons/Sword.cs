using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    [SerializeField]
    Animator swordAnimator;

    [SerializeField]
    uint damage;

    protected override bool CanFire { get => swordAnimator.GetCurrentAnimatorStateInfo(0).IsName("Initial"); set { } }

    protected override void FireWeapon()
    {
        if (swordAnimator.GetCurrentAnimatorStateInfo(0).IsName("Initial"))
        {
            swordAnimator.SetTrigger("Swing");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RunTriggerChecks(other);
    }



    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     RunTriggerChecks(other);
    // }

    private void OnCollisionEnter2D(Collision2D other)
    {
        RunTriggerChecks(other);
    }

    // private void OnCollisionStay2D(Collision2D other)
    // {
    //     RunTriggerChecks(other);
    // }

    void RunTriggerChecks(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        var enemy = other.gameObject.GetComponent<Enemy>();
        Debug.LogWarning("Enemy Collider: " + (enemy != null));

        if (isPlayer && enemy != null)
        {
            enemy.Damage(damage);
        }
        else if (!isPlayer && player != null)
        {
            player.Damage(damage);
        }
    }

    void RunTriggerChecks(Collision2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        var enemy = other.gameObject.GetComponent<Enemy>();
        Debug.LogWarning("Enemy Collision: " + (enemy != null));

        if (isPlayer && enemy != null)
        {
            enemy.Damage(damage);
        }
        else if (!isPlayer && player != null)
        {
            player.Damage(damage);
        }
    }
}
