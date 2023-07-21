using UnityEngine;

internal sealed class PauseManager : BaseEnabled, IUpdate
{
    public EventHandler<bool> OnPauseChanged;

    private PauseController _pauseController;
    private PauseKeyController _pauseKeyController;
    private PauseButtonController _pauseButtonController;

    public PauseManager() : base()
    {
        OnPauseChanged = new EventHandler<bool>();

        _pauseController = new PauseController();
        _pauseController.OnChanged.AddHandler(OnPauseChanged.Handle);

        _pauseKeyController = new PauseKeyController();
        _pauseKeyController.OnKeyPressed.AddHandler(_pauseController.Change);

        _pauseButtonController = new PauseButtonController();
        OnPauseChanged.AddHandler(_pauseButtonController.OnPauseChanged);
        _pauseButtonController.OnButtonClicked.AddHandler(_pauseController.Change);

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
