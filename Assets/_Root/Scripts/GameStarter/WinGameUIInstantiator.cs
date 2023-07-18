using UnityEngine;

internal sealed class WinGameUIInstantiator
{
    public void Instantiate()
    {
        GameObject prefab = Resources.Load<GameObject>("WinGameCanvas");
        GameObject.Instantiate(prefab);
    }
}
