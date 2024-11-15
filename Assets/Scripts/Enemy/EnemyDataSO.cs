using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    [SerializeField]
    int spawnCost;

    [SerializeField]
    int health;

    [SerializeField]
    bool canBeKnockedBack;

    [SerializeField]
    int damage;

    [SerializeField]
    float maxSpeed;

    [SerializeField]
    float impulseForce;

    [SerializeField]
    int moneyAwarded;

    public virtual int Health { get { return health; } }
    public bool CanBeKnockedBack { get => canBeKnockedBack; }
    public virtual int Damage { get { return damage; } }
    public virtual float MaxSpeed { get { return maxSpeed; } }
    public virtual float ImpulseForce { get { return impulseForce; } }

    public int MoneyAwarded { get => moneyAwarded; }
    public int SpawnCost { get => spawnCost; }
}
