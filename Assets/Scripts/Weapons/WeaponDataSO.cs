using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData-", menuName = "Game/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    [SerializeField]
    string weaponName;

    [SerializeField]
    Sprite weaponSprite;

    [SerializeField]
    List<CostAndProjectile> projectile;

    [SerializeField]
    List<CostAndInt> ammoCapacity;

    [SerializeField]
    List<CostAndFloat> knockBack;

    [SerializeField]
    List<CostAndFloatList> projectileSpawns;

    [SerializeField]
    List<CostAndFloat> reloadTime;

    public string WeaponName { get => weaponName; }
    public Sprite WeaponSprite { get => weaponSprite; }
    public List<CostAndProjectile> Projectile { get => projectile; }
    public List<CostAndInt> AmmoCapacity { get => ammoCapacity; }
    public List<CostAndFloat> KnockBack { get => knockBack; }
    public List<CostAndFloat> ReloadTime { get => reloadTime; }
    public List<CostAndFloatList> ProjectileSpawns { get => projectileSpawns; }
}
