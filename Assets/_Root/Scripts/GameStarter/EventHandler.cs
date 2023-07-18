using System;
using System.Collections.Generic;

internal class EventHandler
{
    private List<Action> _list;

    public EventHandler()
    {
        _list = new List<Action>();
    }

    public void AddHandler(Action handler)
    {
        _list.Add(handler);
    }

    public void RemoveHandler(Action handler)
    {
        _list.Remove(handler);
    }

    public virtual void Handle()
    {
        foreach (Action handler in _list)
        {
            handler.Invoke();
        }
    }
}

internal class EventHandler<T>
{
    private List<Action<T>> _list;

    public EventHandler()
    {
        _list = new List<Action<T>>();
    }

    public void AddHandler(Action<T> handler)
    {
        _list.Add(handler);
    }

    public void RemoveHandler(Action<T> handler)
    {
        _list.Remove(handler);
    }

    public virtual void Handle(T handleParam)
    {
        foreach (Action<T> handler in _list)
        {
            handler.Invoke(handleParam);
        }
    }
}

internal class EventHandler<T1, T2>
{
    private List<Action<T1, T2>> _list;

    public EventHandler()
    {
        _list = new List<Action<T1, T2>>();
    }

    public void AddHandler(Action<T1, T2> handler)
    {
        _list.Add(handler);
    }

    public void RemoveHandler(Action<T1, T2> handler)
    {
        _list.Remove(handler);
    }

    public virtual void Handle(T1 handleParam1, T2 handleParam2)
    {
        foreach (Action<T1, T2> handler in _list)
        {
            handler.Invoke(handleParam1, handleParam2);
        }
    }
}