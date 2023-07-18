
using System;

internal sealed class Timer : IUpdate
{
    private UpdateController _updateController;
    private float _time;
    private Action _onComplete;

    public Timer(UpdateController updateController, float time, Action onComplete)
    {
        _updateController = updateController;
        _time = time;
        _onComplete = onComplete;

        _updateController.Add(this);
    }

    public void Update(float deltaTime)
    {
        _time -= deltaTime;
        if (_time > 0f) return;

        _updateController.Remove(this);
        _onComplete.Invoke();
    }
}
