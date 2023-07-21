using UnityEngine;

internal sealed class PauseManager : BaseEnabled, IUpdate
{
    public EventHandler<bool> OnPauseChanged;

    private PauseController _pauseController;
    private PauseKeyController _pauseKeyController;

    public PauseManager() : base()
    {
        OnPauseChanged = new EventHandler<bool>();

        _pauseController = new PauseController();
        _pauseController.OnChanged.AddHandler(OnPauseChanged.Handle);

        _pauseKeyController = new PauseKeyController();
        _pauseKeyController.OnKeyPressed.AddHandler(_pauseController.Change);
    }

    public void Update(float deltaTime)
    {
        if (!_enable) return;

        _pauseKeyController.Update();
    }

    public void OnWinGame()
    {
        _pauseController.Set(false);
        _enable = false;
    }
}
