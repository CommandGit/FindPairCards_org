
internal sealed class PauseController
{
    public EventHandler<bool> OnChanged = new EventHandler<bool>();

    private bool _value = false;

    public void Set(bool newValue)
    {
        _value = newValue;
        OnChanged.Handle(_value);
    }

    public void Change()
    {
        Set(!_value);
    }
}
