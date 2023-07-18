using System;

internal interface IDestroyable
{
    public event Action ActionOnDestroy;
}
