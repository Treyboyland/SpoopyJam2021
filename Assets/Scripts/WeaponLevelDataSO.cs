using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponLevelData-", menuName = "Game/Weapon Levels")]
public class WeaponLevelDataSO : ScriptableObject
{
    [SerializeField]
    WeaponTypeSO weaponType;

    [SerializeField]
    List<UpgradeAndValue<List<int>>> intUpgrades;

    [SerializeField]
    List<UpgradeAndValue<List<float>>> floatUpgrades;

    [SerializeField]
    List<UpgradeAndValue<ListFloatsAsString>> floatListUpgrades;

    public WeaponTypeSO WeaponType { get => weaponType; }

    public object GetLevelsForUpgrade(PlayerUpgradeSO upgrade)
    {
        bool intHas = intUpgrades.Where(x => x.Upgrade == upgrade).Any();
        bool floatHas = floatUpgrades.Where(x => x.Upgrade == upgrade).Any();
        bool floatListHas = floatUpgrades.Where(x => x.Upgrade == upgrade).Any();

        if (intHas)
        {
            return intUpgrades.Where(x => x.Upgrade == upgrade).First().Value;
        }

        if (floatHas)
        {
            return floatUpgrades.Where(x => x.Upgrade == upgrade).First().Value;
        }

        if (floatListHas)
        {
            return floatListUpgrades.Where(x => x.Upgrade == upgrade).First().Value;
        }

        return null;
    }
}
