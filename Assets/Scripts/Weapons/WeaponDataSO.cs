using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData-", menuName = "Game/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{

    [SerializeField]
    WeaponTypeSO weaponType;

    [SerializeField]
    Projectile projectile;

    [SerializeField]
    Vector3 projectileOrigin;

    [SerializeField]
    GameEvent weaponFiredEvent;

    [Tooltip("If the weapon should fire an event instead of projectiles")]
    [SerializeField]
    bool firesEventInstead;

    [SerializeField]
    GameEvent eventToFire;

    [SerializeField]
    List<UpgradeAndValue<int>> intUpgrades;

    [SerializeField]
    List<UpgradeAndValue<float>> floatUpgrades;

    [SerializeField]
    List<UpgradeAndValue<ListFloatsAsString>> floatListUpgrades;

    public WeaponTypeSO WeaponType => weaponType;

    public Projectile Projectile { get => projectile; }
    public Vector3 ProjectileOrigin { get => projectileOrigin; }

    /// <summary>
    /// Event that should be invoked if the weapon fires an event instead of
    /// projectiles
    /// </summary>
    /// <value></value>
    public GameEvent WeaponEvent { get => eventToFire; }

    /// <summary>
    /// Event that should be invoked if not using event fire
    /// </summary>
    /// <value></value>
    public GameEvent WeaponFiredEvent { get => weaponFiredEvent; }
    public bool FiresEventInstead { get => firesEventInstead; }

    public object GetUpgrade(PlayerUpgradeSO upgrade)
    {
        bool hasInt = intUpgrades.Where(x => x.Upgrade == upgrade).Count() != 0;
        bool hasFloat = floatUpgrades.Where(x => x.Upgrade == upgrade).Count() != 0;
        bool hasFloatList = floatListUpgrades.Where(x => x.Upgrade == upgrade).Count() != 0;

        if (hasInt)
        {
            return intUpgrades.Where(x => x.Upgrade == upgrade).First().Value;
        }

        if (hasFloat)
        {
            return floatUpgrades.Where(x => x.Upgrade == upgrade).First().Value;
        }

        if (hasFloatList)
        {
            return floatListUpgrades.Where(x => x.Upgrade == upgrade).First().Value;
        }

        return null;
    }

    public void SetUpgrade(PlayerUpgradeSO upgrade, object value)
    {
        Type t = value.GetType();
        if (t == typeof(float))
        {
            bool exists = floatUpgrades.Where(x => x.Upgrade == upgrade).Count() != 0;
            if (exists)
            {
                for (int i = 0; i < floatUpgrades.Count; i++)
                {
                    if (floatUpgrades[i].Upgrade == upgrade)
                    {
                        var temp = floatUpgrades[i];
                        temp.Value = (float)value;
                        floatUpgrades[i] = temp;
                        break;
                    }
                }
            }
            else
            {
                floatUpgrades.Add(new UpgradeAndValue<float>() { Upgrade = upgrade, Value = (float)value });
            }
        }
        else if (t == typeof(int))
        {
            bool exists = intUpgrades.Where(x => x.Upgrade == upgrade).Count() != 0;
            if (exists)
            {
                for (int i = 0; i < intUpgrades.Count; i++)
                {
                    if (intUpgrades[i].Upgrade == upgrade)
                    {
                        var temp = intUpgrades[i];
                        temp.Value = (int)value;
                        intUpgrades[i] = temp;
                        break;
                    }
                }
            }
            else
            {
                intUpgrades.Add(new UpgradeAndValue<int>() { Upgrade = upgrade, Value = (int)value });
            }
        }
        else if (t == typeof(ListFloatsAsString))
        {
            bool exists = floatListUpgrades.Where(x => x.Upgrade == upgrade).Count() != 0;
            if (exists)
            {
                for (int i = 0; i < floatListUpgrades.Count; i++)
                {
                    if (floatListUpgrades[i].Upgrade == upgrade)
                    {
                        var temp = floatListUpgrades[i];
                        temp.Value = (ListFloatsAsString)value;
                        floatListUpgrades[i] = temp;
                        break;
                    }
                }
            }
            else
            {
                floatListUpgrades.Add(new UpgradeAndValue<ListFloatsAsString>() { Upgrade = upgrade, Value = (ListFloatsAsString)value });
            }
        }
        else
        {
            Debug.LogError($"Type: \"{t.Name}\" not in the list of acceptable stuff");
        }
    }
}
