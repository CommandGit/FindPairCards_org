using UnityEngine;

internal sealed class SettingsPanelController 
{
    private SettingsPanelView _settingsPanelView;
    private GameObject _settingsPanelPrefab;
    public SettingsPanelController()
    {
        _settingsPanelPrefab = Resources.Load<GameObject>("Prefabs/UI/SettingsPanel");
        _settingsPanelView = GameObject.FindObjectOfType<SettingsPanelView>();
    }
    public void ShowSettings()
    {
        if (_settingsPanelView == null)
        {
            GameObject go = GameObject.Instantiate(_settingsPanelPrefab);
            _settingsPanelView = go.GetComponent<SettingsPanelView>();
            _settingsPanelView.closeSettingsPanelButton.onClick.AddListener(ClosePanel);
        }
    }
    private void ClosePanel()
    {
        GameObject.Destroy(_settingsPanelView.gameObject);
    }
}
