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

    int damage;

    int ammoCapacity;

    int currentAmmo;

    float reloadTime;

    float elapsed;

    bool isReloading;
    private float knockBack;

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
                return currentAmmo != 0 && Player.PlayerInstance != null && !Player.PlayerInstance.IsDead;
            }
            else
            {
                return currentAmmo != 0;
            }

        }
    }

    public SpriteRenderer WeaponSprite { get => weaponSprite; set => weaponSprite = value; }
    public Projectile Bullet { get => bullet; set => bullet = value; }
    public Vector3 ProjectileOrigin { get => projectileOrigin; set => projectileOrigin = value; }
    public int AmmoCapacity { get => ammoCapacity; set => ammoCapacity = value; }

    public WeaponTypeSO WeaponType { get; set; }

    public List<float> FireAngles { get; set; }

    public int Damage { get => damage; set => damage = value; }
    public float ReloadTime { get => reloadTime; set => reloadTime = value; }
    public float KnockBack { get => knockBack; set => knockBack = value; }

    public virtual void Fire()
    {
        if (CanFire)
        {
            FireWeapon();
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (isReloading)
        {
            elapsed += Time.deltaTime;
        }

        if (currentAmmo == 0 && !isReloading)
        {
            isReloading = true;
        }

        if (elapsed >= reloadTime)
        {
            elapsed = 0;
            isReloading = false;
            currentAmmo = ammoCapacity;
        }
    }


    protected void FireWeapon()
    {
        currentAmmo--;
        foreach (var item in FireAngles)
        {
            var bulletObj = MasterPool.Pool.GetObject(bullet) as Projectile;
            bulletObj.transform.position = transform.position + projectileOrigin;
            bulletObj.transform.up = transform.up;
            bulletObj.transform.rotation *= Quaternion.AngleAxis(item, Vector3.forward);
            bulletObj.Damage = Damage;
            bulletObj.gameObject.SetActive(true);
        }

        if (onWeaponFired != null)
        {
            onWeaponFired.Invoke();
        }
    }
}
