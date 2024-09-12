using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats-", menuName = "Game/Player Stats")]
public class PlayerStatsSO : ScriptableObject
{
    [SerializeField]
    int startingLives;

    [SerializeField]
    int money;

    [SerializeField]
    WeaponTypeSO leftEquipWeapon;

    [SerializeField]
    WeaponTypeSO rightEquipWeapon;

    [SerializeField]
    List<CostAndInt> livesUpgrades;

    /*
    I don't like this. I feel like there is a more efficient way to do this.
    Some way to dynamically have an upgrade for a particular weapon parameter
    without needing to set up a variable + scriptable object for its choice.
    Reflection maybe, but then how would I choose?
    */

    [SerializeField]
    int upgradeCountLives;

    [SerializeField]
    int upgradeCountPistolDamage;

    [SerializeField]
    int upgradeCountPistolCapacity;

    [SerializeField]
    int upgradeCountPistolReloadSpeed;

    [SerializeField]
    int upgradeCountShotgunCapacity;

    [SerializeField]
    int upgradeCountShotgunKnockback;

    [SerializeField]
    int upgradeCountKunaiCount;

    [SerializeField]
    int upgradeCountKunaiReloadSpeed;

    [Header("Upgrade Enums")]

    [SerializeField]
    PlayerUpgradeSO livesUpgradeSO;

    [SerializeField]
    PlayerUpgradeSO pistolDamageUpgradeSO;

    [SerializeField]
    PlayerUpgradeSO pistolAmmoCapacityUpgradeSO;

    [SerializeField]
    PlayerUpgradeSO pistolReloadSpeedUpgradeSO;

    [SerializeField]
    PlayerUpgradeSO shotgunCapacityUpgradeSO;

    [SerializeField]
    PlayerUpgradeSO shotgunKnockbackUpgradeSO;

    [SerializeField]
    PlayerUpgradeSO kunaiCountUpgradeSO;

    [SerializeField]
    PlayerUpgradeSO kunaiReloadSpeedUpgradeSO;

    public int Money { get => money; set => money = value; }
    public int UpgradeCountLives { get => upgradeCountLives; set => upgradeCountLives = value; }
    public int UpgradeCountPistolDamage { get => upgradeCountPistolDamage; set => upgradeCountPistolDamage = value; }
    public int UpgradeCountPistolCapacity { get => upgradeCountPistolCapacity; set => upgradeCountPistolCapacity = value; }
    public int UpgradeCountPistolReloadSpeed { get => upgradeCountPistolReloadSpeed; set => upgradeCountPistolReloadSpeed = value; }
    public int UpgradeCountShotgunCapacity { get => upgradeCountShotgunCapacity; set => upgradeCountShotgunCapacity = value; }
    public int UpgradeCountShotgunKnockback { get => upgradeCountShotgunKnockback; set => upgradeCountShotgunKnockback = value; }
    public int UpgradeCountKunaiCount { get => upgradeCountKunaiCount; set => upgradeCountKunaiCount = value; }
    public int UpgradeCountKunaiReloadSpeed { get => upgradeCountKunaiReloadSpeed; set => upgradeCountKunaiReloadSpeed = value; }
    public List<CostAndInt> LivesUpgrades { get => livesUpgrades; }
    public WeaponTypeSO RightEquipWeapon { get => rightEquipWeapon; set => rightEquipWeapon = value; }
    public WeaponTypeSO LeftEquipWeapon { get => leftEquipWeapon; set => leftEquipWeapon = value; }
    public int StartingLives { get => startingLives; }

    //TODO: might want to change this to look at the number of bought upgrades
    public int MaxHealth { get => startingLives + upgradeCountLives; }

    public PlayerStatsSO Duplicate()
    {
        var newThing = ScriptableObject.CreateInstance<PlayerStatsSO>();

        newThing.money = money;
        newThing.startingLives = startingLives;
        newThing.livesUpgrades = new List<CostAndInt>(livesUpgrades);
        newThing.upgradeCountLives = upgradeCountLives;
        newThing.upgradeCountPistolDamage = upgradeCountPistolDamage;
        newThing.upgradeCountPistolCapacity = upgradeCountPistolCapacity;
        newThing.upgradeCountPistolReloadSpeed = upgradeCountPistolReloadSpeed;
        newThing.upgradeCountShotgunCapacity = upgradeCountShotgunCapacity;
        newThing.upgradeCountShotgunKnockback = upgradeCountShotgunKnockback;
        newThing.upgradeCountKunaiCount = upgradeCountKunaiCount;
        newThing.upgradeCountKunaiReloadSpeed = upgradeCountKunaiReloadSpeed;

        newThing.livesUpgradeSO = livesUpgradeSO;
        newThing.pistolDamageUpgradeSO = pistolDamageUpgradeSO;
        newThing.pistolAmmoCapacityUpgradeSO = pistolAmmoCapacityUpgradeSO;
        newThing.pistolReloadSpeedUpgradeSO = pistolReloadSpeedUpgradeSO;
        newThing.shotgunCapacityUpgradeSO = shotgunCapacityUpgradeSO;
        newThing.shotgunKnockbackUpgradeSO = shotgunKnockbackUpgradeSO;
        newThing.kunaiCountUpgradeSO = kunaiCountUpgradeSO;
        newThing.kunaiReloadSpeedUpgradeSO = kunaiReloadSpeedUpgradeSO;

        newThing.rightEquipWeapon = rightEquipWeapon;
        newThing.leftEquipWeapon = leftEquipWeapon;

        return newThing;
    }

    public void IncreaseUpgradeCount(PlayerUpgradeSO upgrade)
    {
        if (upgrade == livesUpgradeSO)
        {
            upgradeCountLives++;
        }
        if (upgrade == pistolDamageUpgradeSO)
        {
            upgradeCountPistolDamage++;
        }
        if (upgrade == pistolAmmoCapacityUpgradeSO)
        {
            upgradeCountPistolCapacity++;
        }
        if (upgrade == pistolReloadSpeedUpgradeSO)
        {
            upgradeCountPistolReloadSpeed++;
        }
        if (upgrade == shotgunCapacityUpgradeSO)
        {
            upgradeCountShotgunCapacity++;
        }
        if (upgrade == shotgunKnockbackUpgradeSO)
        {
            upgradeCountShotgunKnockback++;
        }
        if (upgrade == kunaiCountUpgradeSO)
        {
            upgradeCountKunaiCount++;
        }
        if (upgrade == kunaiReloadSpeedUpgradeSO)
        {
            upgradeCountKunaiReloadSpeed++;
        }
    }

    public int GetUpgradeCountOfType(PlayerUpgradeSO upgrade)
    {
        if (upgrade == livesUpgradeSO)
        {
            return upgradeCountLives;
        }
        if (upgrade == pistolDamageUpgradeSO)
        {
            return upgradeCountPistolDamage;
        }
        if (upgrade == pistolAmmoCapacityUpgradeSO)
        {
            return upgradeCountPistolCapacity;
        }
        if (upgrade == pistolReloadSpeedUpgradeSO)
        {
            return upgradeCountPistolReloadSpeed;
        }
        if (upgrade == shotgunCapacityUpgradeSO)
        {
            return upgradeCountShotgunCapacity;
        }
        if (upgrade == shotgunKnockbackUpgradeSO)
        {
            return upgradeCountShotgunKnockback;
        }
        if (upgrade == kunaiCountUpgradeSO)
        {
            return upgradeCountKunaiCount;
        }
        if (upgrade == kunaiReloadSpeedUpgradeSO)
        {
            return upgradeCountKunaiReloadSpeed;
        }

        return -1;
    }
}
