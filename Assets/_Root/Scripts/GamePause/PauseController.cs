
internal sealed class PauseController
{
    public EventHandler OnPauseEnable = new EventHandler();
    public EventHandler OnPauseDisable = new EventHandler();

    private bool _value = false;

    public void Set(bool newValue)
    {
        _value = newValue;

        if (_value)
        {
            OnPauseEnable.Handle();
        }
        else
        {
            OnPauseDisable.Handle();
        }
    }

    public void Change()
    {
        Set(!_value);
    }
}
