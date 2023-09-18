
internal sealed class PauseMenuController : BasePrefabInstantiator
{
    public EventHandler OnSettingsPressed = new EventHandler();
    private PauseMenuView _pauseMenuView;
    public void OnStartGame()
    {
        _pauseMenuView.settingsButton.onClick.AddListener(ShowSettingsEnabled);
    }

    private void ShowSettingsEnabled()
    {
        OnSettingsPressed.Handle();
    }

    public PauseMenuController() : base("Prefabs/UI/PauseGameCanvas")
    {
    }
}
