using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
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
