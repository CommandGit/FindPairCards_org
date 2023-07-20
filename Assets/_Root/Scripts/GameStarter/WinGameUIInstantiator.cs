using UnityEngine;

internal sealed class WinGameUIInstantiator
{
    public void Instantiate()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/UI/WinGameCanvas");
        GameObject.Instantiate(prefab);
    }
}
