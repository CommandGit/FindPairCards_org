using UnityEngine;

internal sealed class PauseController : BaseEnabled, IUpdate
{
    public EventHandler<bool> OnPauseChanged;
    private bool _isGamePaused;

    public PauseController() : base()
    {
        OnPauseChanged = new EventHandler<bool>();
        _isGamePaused = false;
    }

    public void Update(float deltaTime)
    {
        if (!_enable) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePause(!_isGamePaused);
        }
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
