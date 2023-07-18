internal sealed class UpdateRemover
{
    private UpdateController _updateController;
    private IUpdate _controller;

    public UpdateRemover(UpdateController updateController, IUpdate controller)
    {
        _updateController = updateController;
        _controller = controller;
    }

    public void Remove()
    {
        _updateController.Remove(_controller);
    }
}