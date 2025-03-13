using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    ProjectileDataSO dataSO;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    GameEventProjectile onFired;

    [SerializeField]
    bool isPlayer;

    int damage;

    float elapsed = 0;

    float maxTime;

    float knockBack;

    public float KnockBack { get => knockBack; set => knockBack = value; }
    public int Damage { get => damage; set => damage = value; }

    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= maxTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        elapsed = 0;
        maxTime = dataSO.LifeTime;
        body.velocity = transform.up * dataSO.Speed;
        if (gameObject.activeInHierarchy && onFired != null)
        {
            onFired.Invoke(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        var player = other.gameObject.GetComponent<Player>();
        if (isPlayer && enemy != null)
        {
            enemy.KnockBack(knockBack);
            enemy.Damage(damage);
        }
        else if (!isPlayer && player != null)
        {
            player.Damage(damage);
        }

        if (!dataSO.IsPiercing)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        var player = other.gameObject.GetComponent<Player>();
        if (isPlayer && enemy != null)
        {
            enemy.Damage(damage);
        }
        else if (!isPlayer && player != null)
        {
            player.Damage(damage);
        }

        if (!dataSO.IsPiercing)
        {
            gameObject.SetActive(false);
        }
    }
}
