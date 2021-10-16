using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    [SerializeField]
    Animator swordAnimator;

    protected override bool CanFire { get => swordAnimator.GetCurrentAnimatorStateInfo(0).IsName("Initial"); set { } }

    protected override void FireWeapon()
    {
        if (swordAnimator.GetCurrentAnimatorStateInfo(0).IsName("Initial"))
        {
            swordAnimator.SetTrigger("Swing");
        }
    }
}
