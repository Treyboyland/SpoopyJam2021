using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataFinder", menuName = "Game/Weapon Data Finder")]
public class WeaponDataFinder : ScriptableObject
{
    [SerializeField]
    PlayerUpgradeSO ammoCapacity;

    [SerializeField]
    PlayerUpgradeSO reloadTime;

    [SerializeField]
    PlayerUpgradeSO damage;

    [SerializeField]
    PlayerUpgradeSO knockBack;

    [SerializeField]
    PlayerUpgradeSO fireAngles;

    [SerializeField]
    PlayerUpgradeSO energyRecoveryPerSecond;

    [SerializeField]
    PlayerUpgradeSO energyPerShot;

    [SerializeField]
    PlayerUpgradeSO maxEnergy;

    [SerializeField]
    PlayerUpgradeSO secondsBetweenShots;


    public float GetReloadTime(WeaponDataSO weaponData)
    {
        var data = weaponData.GetUpgrade(reloadTime);
        return data != null ? (float)data : -1;
    }

    public int GetAmmoCapacity(WeaponDataSO weaponData)
    {
        var data = weaponData.GetUpgrade(ammoCapacity);
        return data != null ? (int)data : -1;
    }

    public int GetDamage(WeaponDataSO weaponData)
    {
        var data = weaponData.GetUpgrade(damage);
        return data != null ? (int)data : -1;
    }

    public float GetKnockback(WeaponDataSO weaponData)
    {
        var data = weaponData.GetUpgrade(knockBack);
        return data != null ? (float)data : -1;
    }

    public List<float> GetFireAngles(WeaponDataSO weaponData)
    {
        var data = weaponData.GetUpgrade(fireAngles);
        //This was a float list
        return data != null ? ((ListFloatsAsString)data).GetValues() : new List<float>();
    }

    internal float GetEnergyRecoveryPerSecond(WeaponDataSO weaponData)
    {
        var data = weaponData.GetUpgrade(energyRecoveryPerSecond);
        return data != null ? (float)data : -1;
    }

    internal float GetEnergyPerShot(WeaponDataSO weaponData)
    {
        var data = weaponData.GetUpgrade(energyPerShot);
        return data != null ? (float)data : -1;
    }

    internal float GetMaxEnergy(WeaponDataSO weaponData)
    {
        var data = weaponData.GetUpgrade(maxEnergy);
        return data != null ? (float)data : -1;
    }

    internal float GetSecondsBetweenShots(WeaponDataSO weaponData)
    {
        var data = weaponData.GetUpgrade(secondsBetweenShots);
        return data != null ? (float)data : -1;
    }
}
