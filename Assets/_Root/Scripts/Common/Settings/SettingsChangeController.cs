
internal sealed class SettingsChangeController
{
    public EventHandler<SoundSettings> OnSoundSettingsChanged = new EventHandler<SoundSettings>();

    private Settings _settings;

    public SettingsChangeController(Settings settings)
    {
        _settings = settings;
    }

    public void OnSettingsChanged(Settings newSettings)
    {
        _settings = newSettings;

        OnSoundSettingsChanged.Handle(_settings.GameSettings.SoundSettings);
    }

    public void OnStartScene()
    {
        OnSettingsChanged(_settings);
    }
}
