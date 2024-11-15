using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeapnType-", menuName = "Game/Weapon Type")]
public class WeaponTypeSO : ScriptableObject
{
    [SerializeField]
    string weaponName;

    [SerializeField]
    Sprite weaponSprite;


    public string WeaponName => weaponName;

    public Sprite WeaponSprite => weaponSprite;
}
