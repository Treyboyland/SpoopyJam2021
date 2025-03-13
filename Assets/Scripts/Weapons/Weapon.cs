using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected bool isPlayer;

    public bool IsPlayer { get { return isPlayer; } }

    [Header("Parts")]

    [SerializeField]
    SpriteRenderer weaponSprite;

    [SerializeField]
    Projectile bullet;

    [SerializeField]
    Vector3 projectileOrigin;

    [SerializeField]
    GameEvent onWeaponFired;

    [SerializeField]
    GameEventWeaponProgress onEnergyProgressUpdated;

    int damage;
    float energyRecoveryPerSecond;
    float energyPerShot;
    float maxEnergy;
    float secondsBetweenShots;

    float currentEnergy;
    float secondsSinceLastShot;

    bool shouldFireEvent;

    private float knockBack;


    float energyProgress = 0;
    private GameEvent weaponEvent;

    [Serializable]
    public struct TransformRotation
    {
        public Transform Transform;

        public float Rotation;
    }


    protected bool CanFire
    {
        get
        {
            if (isPlayer)
            {
                return currentEnergy >= energyPerShot && secondsSinceLastShot >= secondsBetweenShots && Player.PlayerInstance != null && !Player.PlayerInstance.IsDead;
            }
            else
            {
                return currentEnergy >= energyPerShot && secondsSinceLastShot >= secondsBetweenShots;
            }

        }
    }

    public SpriteRenderer WeaponSprite { get => weaponSprite; set => weaponSprite = value; }
    public Projectile Bullet { get => bullet; set => bullet = value; }
    public Vector3 ProjectileOrigin { get => projectileOrigin; set => projectileOrigin = value; }

    public GameEvent WeaponEvent { get => weaponEvent; set => weaponEvent = value; }

    public WeaponTypeSO WeaponType { get; set; }

    public List<float> FireAngles { get; set; }

    public int Damage { get => damage; set => damage = value; }
    public float KnockBack { get => knockBack; set => knockBack = value; }
    public float EnergyPerShot { get => energyPerShot; set => energyPerShot = value; }
    public float MaxEnergy { get => maxEnergy; set => maxEnergy = value; }
    public float SecondsBetweenShots { get => secondsBetweenShots; set => secondsBetweenShots = value; }


    public float EnergyProgress
    {
        get => energyProgress; set
        {
            energyProgress = value;
            onEnergyProgressUpdated.Invoke(new WeaponProgress() { Progress = energyProgress, CanFire = currentEnergy >= energyPerShot });
        }
    }

    ///  <summary>
    /// If true, fires event instead of projectile. Event handler should decrement energy
    /// </summary>
    /// <value></value>
    public bool ShouldFireEvent { get => shouldFireEvent; set => shouldFireEvent = value; }
    public float CurrentEnergy { get => currentEnergy; }
    public GameEvent OnWeaponFired { get => onWeaponFired; set => onWeaponFired = value; }

    public virtual void Fire()
    {
        if (CanFire)
        {
            if (shouldFireEvent)
            {
                weaponEvent.Invoke();
            }
            else
            {
                DecrementWeaponEnergyForShot();
                FireWeapon();
            }
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (isPlayer)
        {
            currentEnergy = Mathf.Max(0, Mathf.Min(currentEnergy + PlayerGameStats.Instance.InGameStats.EnergyRecoveryPerSecond * Time.deltaTime, maxEnergy));
        }
        else
        {
            currentEnergy = Mathf.Max(0, Mathf.Min(currentEnergy + energyRecoveryPerSecond * Time.deltaTime, maxEnergy));
        }

        EnergyProgress = currentEnergy / maxEnergy;
        secondsSinceLastShot += Time.deltaTime;
        //Debug.LogWarning($"Weapon {CanFire}: {energyPerShot}/{currentEnergy}, {secondsSinceLastShot}/{secondsBetweenShots}");
    }

    public void DecrementWeaponEnergyForShot()
    {
        secondsSinceLastShot = 0;
        currentEnergy -= energyPerShot;
        EnergyProgress = currentEnergy / maxEnergy;
    }


    public virtual void FireWeapon()
    {
        foreach (var item in FireAngles)
        {
            var bulletObj = MasterPool.Pool.GetObject(bullet) as Projectile;
            bulletObj.transform.position = transform.position + projectileOrigin * Mathf.Sin(transform.eulerAngles.z);
            bulletObj.transform.up = transform.up;
            bulletObj.transform.rotation *= Quaternion.AngleAxis(item, Vector3.forward);
            bulletObj.Damage = Damage;
            bulletObj.KnockBack = KnockBack;
            bulletObj.gameObject.SetActive(true);
        }

        if (onWeaponFired != null)
        {
            onWeaponFired.Invoke();
        }
    }

    public void Refill()
    {
        currentEnergy = maxEnergy;
        secondsSinceLastShot = secondsBetweenShots;
    }
}
