using UnityEngine;

internal sealed class SettingsPanelController 
{
    private const float VOLUME_SLIDER_MIN_VALUE = -80f;
    private const float VOLUME_SLIDER_MAX_VALUE = 20f;

    public EventHandler<Settings> OnChangeSettings = new EventHandler<Settings>();

    private SettingsPanelView _settingsPanelView;
    private GameObject _settingsPanelPrefab;
    private Settings _settings;
    public SettingsPanelController(Settings settings)
    {
        _settings = settings;
        _settingsPanelPrefab = Resources.Load<GameObject>("Prefabs/UI/SettingsMenu");
        _settingsPanelView = GameObject.FindObjectOfType<SettingsPanelView>();
    }
    public void ShowSettings()
    {
        if (_settingsPanelView == null)
        {
            GameObject go = GameObject.Instantiate(_settingsPanelPrefab);
            _settingsPanelView = go.GetComponent<SettingsPanelView>();
            AddListeners();
            SetDefaultParameters();
            SetViewValuesFromSettings();
        }
    }

    private void OnMasterVolumeChanged(float value)
    {
        SetSettingsFromViewValues();
        OnChangeSettings.Handle(_settings);
    }

    private void AddListeners()
    {
        _settingsPanelView.closeSettingsPanelButton.onClick.AddListener(ClosePanel);
        _settingsPanelView.SubmitButton.onClick.AddListener(OnSubmitButtonPressed);
        _settingsPanelView.MasterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
    }

    private void RemoveListeners()
    {
        _settingsPanelView.closeSettingsPanelButton.onClick.RemoveAllListeners();
        _settingsPanelView.SubmitButton.onClick.RemoveAllListeners();
        _settingsPanelView.MasterVolumeSlider.onValueChanged.RemoveAllListeners();
    }

    private void OnSubmitButtonPressed()
    {
        ClosePanel();
    }

    private void SetDefaultParameters()
    {
        _settingsPanelView.MasterVolumeSlider.minValue = VOLUME_SLIDER_MIN_VALUE;
        _settingsPanelView.MasterVolumeSlider.maxValue = VOLUME_SLIDER_MAX_VALUE;
    }

    private void SetViewValuesFromSettings()
    {
        _settingsPanelView.MasterVolumeSlider.value = _settings.GameSettings.SoundSettings.MasterVolume;
    }

    private void SetSettingsFromViewValues()
    {
        _settings.GameSettings.SoundSettings.MasterVolume = _settingsPanelView.MasterVolumeSlider.value;
    }

    private void ClosePanel()
    {
        GameObject.Destroy(_settingsPanelView.gameObject);
        RemoveListeners();
        _settingsPanelView = null;
    }
}
