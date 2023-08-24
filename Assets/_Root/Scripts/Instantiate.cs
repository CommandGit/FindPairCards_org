using System.Collections;
using UnityEngine;

    public class Instantiate 
    {
        public virtual GameObject InstantiateObject(string path)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        GameObject.Instantiate(prefab);
        return prefab;
    }
    }
