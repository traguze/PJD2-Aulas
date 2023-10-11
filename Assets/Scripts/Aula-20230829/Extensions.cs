using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    static public float[] ToFloatArray(this Vector3 v, bool useDecimal = false)
    {
        return new float[] { v.x, v.y, v.z };
    }

    static public string ToListString<T>(this IEnumerable<T> list, string separator = ", ")
    {
        List<string> items = new List<string>();

        foreach (var item in list)
        {
            items.Add(item.ToString());
        }

        return string.Join(separator,items);
    }
}
