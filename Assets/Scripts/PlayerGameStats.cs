using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerGameStats : MonoBehaviour
{
    [SerializeField]
    PlayerStatsSO startingStats;

    [Header("Weapons")]

    [SerializeField]
    WeaponDataSO pistol;

    [SerializeField]
    WeaponDataSO shotgun;

    [SerializeField]
    WeaponDataSO kunai;


    [Header("Upgrade Types")]

    [SerializeField]
    PlayerUpgradeSO lives;

    [SerializeField]
    PlayerUpgradeSO pistolDamage;

    [SerializeField]
    PlayerUpgradeSO pistolAmmoCapacity;

    [SerializeField]
    PlayerUpgradeSO pistolReloadSpeed;

    [SerializeField]
    PlayerUpgradeSO shotgunCapacity;

    [SerializeField]
    PlayerUpgradeSO shotgunKnockback;

    [SerializeField]
    PlayerUpgradeSO kunaiCount;

    [SerializeField]
    PlayerUpgradeSO kunaiReloadSpeed;

    [SerializeField]
    GameEvent onRefreshShopCosts;

    [SerializeField]
    GameEvent onItemBoughtSuccess;

    [SerializeField]
    GameEvent onItemBoughtFail;

    PlayerStatsSO inGameStats;

    static PlayerGameStats _instance;

    public static PlayerGameStats Instance => _instance;

    public PlayerStatsSO InGameStats { get => inGameStats; }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        inGameStats = startingStats.Duplicate();
    }

    public int GetUpgradeCost(PlayerUpgradeSO upgrade)
    {
        int upgradeCount = inGameStats.GetUpgradeCountOfType(upgrade);
        //TODO: This feels very wrong...
        if (upgrade == lives)
        {
            return inGameStats.LivesUpgrades.GetCostOfUpgrade(upgradeCount);
        }

        if (upgrade == pistolDamage)
        {
            return pistol.Projectile.GetCostOfUpgrade(upgradeCount);
        }

        if (upgrade == pistolAmmoCapacity)
        {
            return pistol.AmmoCapacity.GetCostOfUpgrade(upgradeCount);
        }

        if (upgrade == pistolReloadSpeed)
        {
            return pistol.ReloadTime.GetCostOfUpgrade(upgradeCount);
        }

        if (upgrade == shotgunCapacity)
        {
            return shotgun.AmmoCapacity.GetCostOfUpgrade(upgradeCount);
        }

        if (upgrade == shotgunKnockback)
        {
            return shotgun.KnockBack.GetCostOfUpgrade(upgradeCount);
        }

        if (upgrade == kunaiCount)
        {
            return kunai.ProjectileSpawns.GetCostOfUpgrade(upgradeCount);
        }

        if (upgrade == kunaiReloadSpeed)
        {
            return kunai.ReloadTime.GetCostOfUpgrade(upgradeCount);
        }


        Debug.LogError($"Unknown upgrade: {upgrade.UpgradeName}");
        return -1;
    }

    public void AttemptUpgrade(PlayerUpgradeSO upgrade)
    {
        int cost = GetUpgradeCost(upgrade);

        if (inGameStats.Money < cost)
        {
            //TODO: Fail upgrade
            onItemBoughtFail.Invoke();
            return;
        }
        else
        {
            onItemBoughtSuccess.Invoke();
            inGameStats.Money -= cost;
            inGameStats.IncreaseUpgradeCount(upgrade);
            onRefreshShopCosts.Invoke();
        }
    }

}
