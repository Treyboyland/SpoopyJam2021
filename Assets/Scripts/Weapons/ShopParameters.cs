using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct EquipData
{
    public bool IsLeft;
    public WeaponTypeSO WeaponType;
}

[Serializable]
public abstract class CostAndSomething<T>
{
    public int Cost;
    public T Value;
}

[Serializable]
public class CostAndInt : CostAndSomething<int>
{
}

[Serializable]
public class CostAndFloat : CostAndSomething<float>
{
}

[Serializable]
public class CostAndFloatList : CostAndSomething<List<float>>
{
}

[Serializable]
public class CostAndProjectile : CostAndSomething<Projectile>
{

}


public static class CostExtensions
{

    public static int GetCostOfUpgrade<T>(this List<CostAndSomething<T>> costs, int level)
    {
        if (costs.Count == 0)
        {
            return -1;
        }
        if (level < 0)
        {
            return costs[0].Cost;
        }

        return level < costs.Count ? costs[level].Cost : costs.Last().Cost;
    }

    public static int GetCostOfUpgrade<T>(this IEnumerable<CostAndSomething<T>> costs, int level)
    {
        return costs.ToList().GetCostOfUpgrade(level);
    }

    public static T GetThingAtLevel<T>(this List<CostAndSomething<T>> costs, int level)
    {
        if (costs.Count == 0)
        {
            return default(T);
        }
        if (level < 0)
        {
            return costs[0].Value;
        }

        return level < costs.Count ? costs[level].Value : costs.Last().Value;
    }

    public static T GetThingAtLevel<T>(this IEnumerable<CostAndSomething<T>> costs, int level)
    {
        return costs.ToList().GetThingAtLevel(level);
    }
}