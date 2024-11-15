using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerGameStats : MonoBehaviour
{
    [SerializeField]
    PlayerStatsSO startingStats;

    [SerializeField]
    List<WeaponTypeAndShopData> shops;

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

    public int GetUpgradeCost(WeaponTypeAndPlayerUpgrade upgradeData)
    {
        return GetUpgradeCost(upgradeData.WeaponType, upgradeData.PlayerUpgrade);
    }

    public int GetUpgradeCost(WeaponTypeSO weapon, PlayerUpgradeSO upgrade)
    {
        int upgradeCount = inGameStats.GetCountOfUpgradeType(weapon, upgrade);

        if (upgradeCount == -1)
        {
            Debug.LogError($"Unknown upgrade: {upgrade.UpgradeName} with type {(weapon != null ? weapon.WeaponName : "NULL")}");
            return upgradeCount;
        }

        upgradeCount++;

        bool hasShop = shops.Where(x => x.WeaponType == weapon).Count() != 0;

        if (hasShop)
        {
            List<int> costs = shops.Where(x => x.WeaponType == weapon).First().ShopData.GetCostsForUpgrade(upgrade);

            return upgradeCount < costs.Count && upgradeCount >= 0 ? costs[upgradeCount] : -1;
        }

        return -1;
    }

    public void AttemptUpgrade(WeaponTypeAndPlayerUpgrade upgrade)
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
