
internal class BaseEnabled
{
    protected bool _enable;

    public BaseEnabled()
    {
        _enable = false;
    }

    public void Enable()
    {
        _enable = true;
    }

    public void Disable()
    {
        _enable = false;
    }

    public bool IsEnabled()
    {
        return _enable;
    }
}
