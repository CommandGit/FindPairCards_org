using System.Collections.Generic;

internal sealed class UpdateController
{
    private List<IUpdate> _updateList = new List<IUpdate>();
    private List<IUpdate> _listToRemove = new List<IUpdate>();
    private List<IUpdate> _listToAdd = new List<IUpdate>();

    public void Add(IUpdate controller)
    {
        _listToAdd.Add(controller);
    }

    public void Remove(IUpdate controller)
    {
        _listToRemove.Add(controller);
    }

    public void AddToView(IUpdate controller, IDestroyable destroyableView)
    {
        Add(controller);
        destroyableView.ActionOnDestroy += new UpdateRemover(this, controller).Remove;
    }

    private void CheckRemoved()
    {
        if (_listToRemove.Count == 0) return;

        foreach (IUpdate controller in _listToRemove)
        {
            _updateList.Remove(controller);
        }
        _listToRemove.Clear();
    }

    private void CheckAdded()
    {
        if (_listToAdd.Count == 0) return;

        foreach (IUpdate controller in _listToAdd)
        {
            _updateList.Add(controller);
        }
        _listToAdd.Clear();
    }

    public void Update(float deltaTime)
    {
        CheckRemoved();
        CheckAdded();

        foreach (IUpdate update in _updateList)
        {
            update.Update(deltaTime);
        }
    }
}
