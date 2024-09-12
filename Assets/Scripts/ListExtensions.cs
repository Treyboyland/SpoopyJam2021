using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static T GetRandomItem<T>(this List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            return default(T);
        }
        return list[Random.Range(0, list.Count)];
    }
}

public static class VectorExtensions
{
    public static float Randomize(this Vector2 x)
    {
        return Random.Range(x.x, x.y);
    }

    public static float Randomize(this Vector2Int x)
    {
        return Random.Range(x.x, x.y);
    }


    public static Vector2 Randomize(this Vector4 a)
    {
        Vector2 x = new Vector2(a.x, a.y);
        Vector2 y = new Vector2(a.z, a.w);
        return new Vector2(x.Randomize(), y.Randomize());
    }
}
