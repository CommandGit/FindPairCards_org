
using UnityEngine;

internal sealed class SettingsController
{
    private const string PREFAB_PATH = "Prefabs/Settings/Settings";

    private SettingsView _settingsView;

    public SettingsController()
    {
        _settingsView = GameObject.FindObjectOfType<SettingsView>();
        if (_settingsView == null) CreateNew();
    }

    private void CreateNew()
    {
        GameObject prefab = Resources.Load<GameObject>(PREFAB_PATH);
        GameObject go = GameObject.Instantiate(prefab);
        GameObject.DontDestroyOnLoad(go);
        _settingsView = go.GetComponent<SettingsView>();
        _settingsView.Settings = new Settings();
    }

    public Settings GetSettings()
    {
        return _settingsView.Settings;
    }
}
