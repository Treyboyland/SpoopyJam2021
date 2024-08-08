using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gun : Weapon
{
    [SerializeField]
    Projectile bullet;

    [SerializeField]
    List<TransformRotation> spawnPoints;

    [SerializeField]
    GameEvent onWeaponFired;

    [Serializable]
    public struct TransformRotation
    {
        public Transform Transform;

        public float Rotation;
    }


    protected override void FireWeapon()
    {
        foreach (var item in spawnPoints)
        {
            var bulletObj = MasterPool.Pool.GetObject(bullet) as Projectile;
            bulletObj.transform.position = item.Transform.position;
            bulletObj.transform.up = transform.up;
            bulletObj.transform.rotation *= Quaternion.AngleAxis(item.Rotation, Vector3.forward);
            bulletObj.gameObject.SetActive(true);
        }

        if (onWeaponFired != null)
        {
            onWeaponFired.Invoke();
        }
    }
}
