
internal sealed class PauseMenu : BasePrefabInstantiator
{
    public PauseMenu() : base("Prefabs/UI/PauseGameCanvas")
    {

    }

    public void OnPauseChanged(bool pauseValue)
    {
        if (pauseValue)
            Show();
        else
            Hide();
    }
}
