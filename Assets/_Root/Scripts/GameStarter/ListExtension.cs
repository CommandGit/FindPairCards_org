using System.Collections.Generic;
using UnityEngine;

namespace Extension
{
    public static class ListExtension
    {
        public static int GetRandomIndex<T>(this List<T> list)
        {
            return Random.Range(0, list.Count);
        }

        public static T GetRandom<T>(this List<T> list)
        {
            return list[list.GetRandomIndex()];
        }

        public static T GetRandomAndRemove<T>(this List<T> list)
        {
            int index = list.GetRandomIndex();
            T returnValue = list[index];
            list.RemoveAt(index);
            return returnValue;
        }
    }
}
