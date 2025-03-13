using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats-", menuName = "Game/Player Stats")]
public class PlayerStatsSO : ScriptableObject
{
    [SerializeField]
    int startingLives;

    [SerializeField]
    int money;

    [SerializeField]
    List<int> moneyMultiplier;

    [SerializeField]
    List<float> dashTimeUpgrades;

    [SerializeField]
    List<float> dashInvincibilityUpgrades;

    [SerializeField]
    List<float> energyRecoveryUpgrades;

    [SerializeField]
    WeaponTypeSO leftEquipWeapon;

    [SerializeField]
    WeaponTypeSO rightEquipWeapon;

    [SerializeField]
    PlayerUpgradeSO lifeUpgrade;

    [SerializeField]
    PlayerUpgradeSO multiplierUpgrade;

    [SerializeField]
    PlayerUpgradeSO dashTimeUpgrade;

    [SerializeField]
    PlayerUpgradeSO dashInvincibilityUpgrade;

    [SerializeField]
    PlayerUpgradeSO energyRecoveryPerSecond;

    /*
    I don't like this. I feel like there is a more efficient way to do this.
    Some way to dynamically have an upgrade for a particular weapon parameter
    without needing to set up a variable + scriptable object for its choice.
    Reflection maybe, but then how would I choose?
    */

    [SerializeField]
    List<WeaponTypeAndUpgradeCount> levelsForUpgrade;

    public int Money { get => money; set => money = value; }

    public WeaponTypeSO RightEquipWeapon { get => rightEquipWeapon; set => rightEquipWeapon = value; }
    public WeaponTypeSO LeftEquipWeapon { get => leftEquipWeapon; set => leftEquipWeapon = value; }
    public int StartingLives { get => startingLives; }

    //TODO: might want to change this to look at the number of bought upgrades
    public int MaxHealth
    {
        get
        {
            int addition = GetCountOfUpgradeType(null, lifeUpgrade) != -1 ? GetCountOfUpgradeType(null, lifeUpgrade) : 0;
            return startingLives + addition;
        }
    }

    public int MoneyMultiplier
    {
        get
        {
            int index = GetCountOfUpgradeType(null, multiplierUpgrade);
            if (index == -1)
            {
                return 1;
            }
            if (index >= moneyMultiplier.Count)
            {
                index = moneyMultiplier.Count - 1;
            }
            return moneyMultiplier[index];
        }
    }

    public float DashTime
    {
        get
        {
            int index = GetCountOfUpgradeType(null, dashTimeUpgrade);
            if (index == -1)
            {
                return 1;
            }
            if (index >= dashTimeUpgrades.Count)
            {
                index = dashTimeUpgrades.Count - 1;
            }
            return dashTimeUpgrades[index];
        }
    }

    public float EnergyRecoveryPerSecond
    {
        get
        {
            int index = GetCountOfUpgradeType(null, energyRecoveryPerSecond);
            if (index == -1)
            {
                return 1;
            }
            if (index >= energyRecoveryUpgrades.Count)
            {
                index = energyRecoveryUpgrades.Count - 1;
            }
            return energyRecoveryUpgrades[index];
        }
    }

    public float DashInvincibility
    {
        get
        {
            int index = GetCountOfUpgradeType(null, dashInvincibilityUpgrade);
            if (index == -1)
            {
                return 1;
            }
            if (index >= dashInvincibilityUpgrades.Count)
            {
                index = dashInvincibilityUpgrades.Count - 1;
            }
            return dashInvincibilityUpgrades[index];
        }
    }

    public PlayerStatsSO Duplicate()
    {
        var newThing = ScriptableObject.CreateInstance<PlayerStatsSO>();

        newThing.money = money;
        newThing.startingLives = startingLives;
        newThing.lifeUpgrade = lifeUpgrade;
        newThing.moneyMultiplier = new List<int>(moneyMultiplier);
        newThing.dashTimeUpgrade = dashTimeUpgrade;
        newThing.dashInvincibilityUpgrade = dashInvincibilityUpgrade;
        newThing.multiplierUpgrade = multiplierUpgrade;

        newThing.dashTimeUpgrades = new List<float>(dashInvincibilityUpgrades);
        newThing.dashInvincibilityUpgrades = new List<float>(dashInvincibilityUpgrades);

        newThing.energyRecoveryPerSecond = energyRecoveryPerSecond;
        newThing.energyRecoveryUpgrades = new List<float>(energyRecoveryUpgrades);


        newThing.levelsForUpgrade = new List<WeaponTypeAndUpgradeCount>();
        foreach (var upgrade in levelsForUpgrade)
        {
            var temp = new WeaponTypeAndUpgradeCount()
            {
                WeaponType = upgrade.WeaponType,
                Upgrades = new List<UpgradeAndValue<int>>()
            };
            foreach (var item in upgrade.Upgrades)
            {
                temp.Upgrades.Add(item);
            }
            newThing.levelsForUpgrade.Add(temp);
        }

        newThing.rightEquipWeapon = rightEquipWeapon;
        newThing.leftEquipWeapon = leftEquipWeapon;

        return newThing;
    }

    public void IncreaseUpgradeCount(WeaponTypeAndPlayerUpgrade upgrade)
    {
        IncreaseUpgradeCount(upgrade.WeaponType, upgrade.PlayerUpgrade);
    }

    public void IncreaseUpgradeCount(WeaponTypeSO weapon, PlayerUpgradeSO upgrade)
    {
        //Weapon and upgrade exists
        var exists = levelsForUpgrade.Where(x => x.WeaponType == weapon &&
         x.Upgrades.Where(y => y.Upgrade == upgrade).Count() != 0).Count() != 0;

        if (exists)
        {
            for (int i = 0; i < levelsForUpgrade.Count; i++)
            {
                if (levelsForUpgrade[i].WeaponType == weapon)
                {
                    for (int k = 0; k < levelsForUpgrade[i].Upgrades.Count; k++)
                    {
                        if (levelsForUpgrade[i].Upgrades[k].Upgrade == upgrade)
                        {
                            var temp = levelsForUpgrade[i].Upgrades[k];
                            temp.Value++;
                            levelsForUpgrade[i].Upgrades[k] = temp;
                            break;
                        }

                    }
                    break;
                }
            }
        }
    }

    public int GetCountOfUpgradeType(WeaponTypeSO weapon, PlayerUpgradeSO upgrade)
    {
        var exists = levelsForUpgrade.Where(x => x.WeaponType == weapon &&
         x.Upgrades.Where(y => y.Upgrade == upgrade).Count() != 0).Count() != 0;

        if (exists)
        {
            return levelsForUpgrade.Where(x => x.WeaponType == weapon).First()
                .Upgrades.Where(y => y.Upgrade == upgrade).First().Value;
        }

        return -1;
    }

    public int GetTotalNumOfUpgrades()
    {
        int count = 0;
        foreach (var upgradeType in levelsForUpgrade)
        {
            foreach (var upgrade in upgradeType.Upgrades)
            {
                count += upgrade.Value;
            }
        }

        return count;
    }
}
