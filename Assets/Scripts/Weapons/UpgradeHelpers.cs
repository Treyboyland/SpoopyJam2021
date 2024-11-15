using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct UpgradeAndValue<T>
{
    public PlayerUpgradeSO Upgrade;
    public T Value;
}

[Serializable]
public struct WeaponTypeAndShopData
{
    public WeaponTypeSO WeaponType;
    public ShopDataSO ShopData;
}

[Serializable]
public struct WeaponTypeAndUpgradeCount
{
    public WeaponTypeSO WeaponType;
    public List<UpgradeAndValue<int>> Upgrades;
}

[Serializable]
public struct ListFloatsAsString
{
    public string Delimiter;
    public string Value;

    public List<float> GetValues()
    {
        var splits = Value.Split(new string[] { Delimiter }, StringSplitOptions.RemoveEmptyEntries);
        List<float> toReturn = new List<float>(splits.Length);

        for (int i = 0; i < splits.Length; i++)
        {
            toReturn.Add(float.Parse(splits[i]));
        }

        return toReturn;
    }
}

[Serializable]
public struct WeaponTypeAndPlayerUpgrade
{
    public WeaponTypeSO WeaponType;
    public PlayerUpgradeSO PlayerUpgrade;
}


public static class ListRectifiers
{
    public static object GetAtIndexOfObjectList(this object obj, int index)
    {
        Type t = obj.GetType();

        if (t == typeof(List<int>))
        {
            var newObj = (List<int>)obj;
            return newObj[index];
        }
        else if (t == typeof(List<float>))
        {
            var newObj = (List<float>)obj;
            return newObj[index];
        }
        else if (t == typeof(ListFloatsAsString))
        {
            var newObj = (ListFloatsAsString)obj;
            return newObj.GetValues()[index];
        }

        return null;
    }
}