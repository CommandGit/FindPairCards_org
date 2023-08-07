using UnityEngine;

internal sealed class WinGameUIInstantiator:Instantiate
{
    private const string PREFAB_PATH = "Prefabs/UI/WinGameCanvas";

    public void Instantiate()
    {
       InstantiateObject(PREFAB_PATH);
    }
}
