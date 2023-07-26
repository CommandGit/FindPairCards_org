
internal sealed class PauseManager : BaseEnabled, IUpdate
{
    public EventHandler OnPauseEnable = new EventHandler();
    public EventHandler OnPauseDisable = new EventHandler();

    private PauseController _pauseController;
    private PauseKeyController _pauseKeyController;
    private PauseButtonController _pauseButtonController;

    public PauseManager() : base()
    {
        _pauseController = new PauseController();
        _pauseController.OnPauseEnable.AddHandler(OnPauseEnable.Handle);
        _pauseController.OnPauseDisable.AddHandler(OnPauseDisable.Handle);

        _pauseKeyController = new PauseKeyController();
        _pauseKeyController.OnKeyPressed.AddHandler(_pauseController.Change);

        _pauseButtonController = new PauseButtonController();
        OnPauseEnable.AddHandler(_pauseButtonController.Hide);
        OnPauseDisable.AddHandler(_pauseButtonController.Show);
        _pauseButtonController.OnButtonClicked.AddHandler(OnPauseButtonPressed);

    }

    private void OnPauseButtonPressed()
    {
        if (!_enable) return;

        _pauseController.Change();
    }

    public void Update(float deltaTime)
    {
        if (!_enable) return;

        _pauseKeyController.Update();
    }

    public void OnStartGame()
    {
        Enable();
        _pauseButtonController.Show();
    }

    public void OnWinGame()
    {
        _pauseController.Set(false);
        Disable();
        _pauseButtonController.Hide();
    }
}
