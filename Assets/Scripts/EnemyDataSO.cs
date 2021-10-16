using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    [SerializeField]
    uint health;

    public virtual uint Health { get { return health; } }

    [SerializeField]
    uint damage;

    public virtual uint Damage { get { return damage; } }
}
