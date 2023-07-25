using UnityEngine;

internal sealed class SettingsPanelController : BaseEnabled, IUpdate
{
    private SettingsPanelView _settingsPanelView;
    private GameObject _settingsPanelPrefab;
    private SettingsPanelModelSettings _settingsPanelModelSettings;

    public SettingsPanelController()
    {
        _settingsPanelModelSettings = _settingsPanelModelSettings = Resources.Load<SettingsPanelModelSettings>("ScriptableObject/SettingsPanelModelSettings");
        _settingsPanelPrefab = Resources.Load<GameObject>("Prefabs/UI/SettingsPanel");
        _settingsPanelView = GameObject.FindObjectOfType<SettingsPanelView>();
    }
    private void ShowSettings()
    {
        if (_settingsPanelView == null)
        {

        GameObject go = GameObject.Instantiate(_settingsPanelPrefab);
        _settingsPanelView = go.GetComponent<SettingsPanelView>();
        }
    }
    public void OnStartGame()
    {
        _settingsPanelModelSettings.IsEnable = false;
        if (_settingsPanelView != null)
        {
            _settingsPanelView.closeSettingsPanelButton.onClick.AddListener(ClosePanel);
        }
    }
    public void Update(float deltaTime)
    {
        if (!_settingsPanelModelSettings.IsEnable) return;
        if (_settingsPanelModelSettings.IsEnable == true)
        {
            ShowSettings();   
        }

    }
    private void ClosePanel()
    {
        if (_settingsPanelView != null)
        {
            if (_settingsPanelModelSettings.IsEnable == true)
            {
                _settingsPanelModelSettings.IsEnable = false;
            }
        }
    }
}
