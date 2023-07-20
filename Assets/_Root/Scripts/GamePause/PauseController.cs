using UnityEngine;

internal sealed class PauseController : BaseEnabled, IUpdate
{
    public EventHandler<bool> OnPauseChanged;

    private bool _isGamePaused;
    private PauseKeyController _pauseKeyController;

    public PauseController() : base()
    {
        OnPauseChanged = new EventHandler<bool>();
        _isGamePaused = false;

        _pauseKeyController = new PauseKeyController();
        _pauseKeyController.OnKeyPressed.AddHandler(OnPauseKeyPressed);
    }

    private void OnPauseKeyPressed()
    {
        ChangePause(!_isGamePaused);
    }

    public void Update(float deltaTime)
    {
        if (!_enable) return;

        _pauseKeyController.Update();
    }

    public void OnWinGame()
    {
        ChangePause(false);
        _enable = false;
    }

    private void ChangePause(bool newPauseValue)
    {
        _isGamePaused = newPauseValue;
        OnPauseChanged.Handle(_isGamePaused);
    }
}
