using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected bool isPlayer;

    public bool IsPlayer { get { return isPlayer; } }

    protected virtual bool CanFire { get; set; } = true;


    public virtual void Fire()
    {
        if (CanFire)
        {
            FireWeapon();
        }
    }

    protected abstract void FireWeapon();
}
