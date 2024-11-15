using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName ="ShopData-", menuName ="Game/Shop Data")]
public class ShopDataSO : ScriptableObject
{
    [SerializeField]
    List<UpgradeAndValue<List<int>>> costs;

    public List<int> GetCostsForUpgrade(PlayerUpgradeSO upgrade)
    {
        var hasUpgrade = costs.Where(x => x.Upgrade == upgrade).Count() != 0;

        if (hasUpgrade)
        {
            return costs.Where(x => x.Upgrade == upgrade).First().Value;
        }

        return new List<int>();
    }
}
