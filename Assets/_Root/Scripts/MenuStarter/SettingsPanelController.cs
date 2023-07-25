using UnityEngine;

internal sealed class SettingsPanelController : BaseEnabled, IUpdate
{
    private SettingsPanelView _settingsPanelView;
    private SettingsPanelModel _settingsPanelModel;
    private GameObject _settingsPanelPrefab;


    public SettingsPanelController()
    {
        _settingsPanelModel = new SettingsPanelModel();   
        _settingsPanelPrefab = Resources.Load<GameObject>("Prefabs/UI/SettingsPanel");
        _settingsPanelView = GameObject.FindObjectOfType<SettingsPanelView>();
    }
    private void ShowSettings()
    {
        GameObject go = GameObject.Instantiate(_settingsPanelPrefab);
        _settingsPanelView = go.GetComponent<SettingsPanelView>();
        Debug.Log("ShowSettings");
    }

    public void OnStartGame()
    {
       // Hide();
        //_settingsPanelView.closeSettingsPanelButton.onClick.AddListener(ClosePanel);
    }
    public void Hide()
    {
        _settingsPanelModel.IsEnable = false;

        Debug.Log("hide is hiding");
    }

    public void Update(float deltaTime)
    {
        if (!_enable) return;
        if (!_settingsPanelModel.IsEnable) return;
        if (_settingsPanelModel.IsEnable == true)
        {
            Debug.Log("set panel updateing");
            ShowSettings();
        }
    }

    private void ClosePanel()
    {
        _settingsPanelView.settingsPanelObject.SetActive(false);
    }
}
