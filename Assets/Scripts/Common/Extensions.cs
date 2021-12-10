using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static T GetElementById<T>(this IList<T> list, int id) where T: IIdable
    {
        foreach (var obj in list)
        {
            if (obj.Id.Equals(id))
            {
                return obj;
            }
        }

        return default(T);
    }

    public static T GetElementByName<T>(this IList<T> list, string name) where T: INameable
    {
        foreach (T obj in list)
        {
            if (obj.Name.Equals(name))
            {
                return obj;
            }
        }

        return default(T);
    }
}
