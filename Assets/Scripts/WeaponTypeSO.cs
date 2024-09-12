using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeapnType-", menuName = "Game/Weapon Type")]
public class WeaponTypeSO : ScriptableObject
{
    [SerializeField]
    string weaponName;

    public string WeaponName => weaponName;
}
