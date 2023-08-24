
using UnityEngine;

internal sealed class SettingsController: Instantiate//BasePrefabInstantiator //
{
    private const string PREFAB_PATH = "Prefabs/Settings/Settings";

    private SettingsView _settingsView;


    //public SettingsController() : base(PREFAB_PATH)
    //{

    //    _settingsView = _gameObject.GetComponent<SettingsView>();
    //    if (_settingsView == null) base.Show();
    //}

    public SettingsController()
    {
        _settingsView = GameObject.FindObjectOfType<SettingsView>();
        if (_settingsView == null) CreateNew();
    }

    private void CreateNew()
    {
        GameObject go = InstantiateObject(PREFAB_PATH);
        _settingsView = go.GetComponent<SettingsView>();
        _settingsView.Settings = new Settings();
        GameObject.DontDestroyOnLoad(go);
    }

    public Settings GetSettings()
    {
        return _settingsView.Settings;
    }
}
