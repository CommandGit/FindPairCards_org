
internal class BaseEnabled
{
    protected bool _enable;

    public BaseEnabled()
    {
        _enable = false;
    }

    public virtual void Enable()
    {
        _enable = true;
    }

    public virtual void Disable()
    {
        _enable = false;
    }

    public bool IsEnabled()
    {
        return _enable;
    }
}
