using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Game/Projectile Data")]
public class ProjectileDataSO : ScriptableObject
{
    [Tooltip("How much damage this does on contact")]
    [SerializeField]
    uint damage;

    /// <summary>
    /// How much damage this does on contact
    /// </summary>
    /// <value></value>
    public uint Damage { get { return damage; } }

    [Tooltip("How long the projectile stays alive in seconds")]
    [SerializeField]
    float lifeTime;

    /// <summary>
    /// How long the projectile stays alive in seconds
    /// </summary>
    /// <value></value>
    public float LifeTime { get { return lifeTime; } }


    [Tooltip("True if the projectile penetrates enemies")]
    [SerializeField]
    bool isPiercing;

    /// <summary>
    /// True if the projectile penetrates enemies
    /// </summary>
    /// <value></value>
    public bool IsPiercing { get { return isPiercing; } }

    [Tooltip("Speed of this projectile")]
    [SerializeField]
    float speed;

    /// <summary>
    /// Speed of this projectile
    /// </summary>
    /// <value></value>
    public float Speed { get { return speed; } }

    [Tooltip("How hard this particle knocks the ghost back on hit")]
    [SerializeField]
    float knockBack;

    /// <summary>
    /// How hard this particle knocks the ghost back on hit
    /// </summary>
    /// <value></value>
    public float KnockBack { get { return knockBack; } }

}
