using UnityEngine;

internal class BasePrefabInstantiator
{
    protected bool _isShown = false;
    private GameObject _prefab;
    protected GameObject _gameObject;

    public BasePrefabInstantiator(string prefabName)
    {
        _prefab = Resources.Load<GameObject>(prefabName);
    }

    public BasePrefabInstantiator(GameObject prefab)
    {
        _prefab = prefab;
    }

    public virtual void Show()
    {
        if (_isShown) return;

        _gameObject = GameObject.Instantiate(_prefab);
        _isShown = true;
    }

    public virtual void Hide()
    {
        if (!_isShown) return;

        GameObject.Destroy(_gameObject);
        _isShown = false;
        _gameObject = null;
    }
}
