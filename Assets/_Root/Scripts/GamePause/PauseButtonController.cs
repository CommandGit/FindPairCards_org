
internal sealed class PauseButtonController : BasePrefabInstantiator
{
    private const string PREFAB_PATH = "Prefabs/UI/PauseButtonCanvas";

    public EventHandler OnButtonClicked;

    private PauseButtonView _view;

    public PauseButtonController() : base(PREFAB_PATH)
    {
        OnButtonClicked = new EventHandler();
    }

    public override void Show()
    {
        base.Show();

        _view = _gameObject.GetComponent<PauseButtonView>();
        _view.PauseButtom.onClick.AddListener(OnPauseButtonClicked);
    }

    public override void Hide()
    {
        _view.PauseButtom.onClick.RemoveAllListeners();
        _view = null;
        
        base.Hide();
    }

    private void OnPauseButtonClicked()
    {
        OnButtonClicked.Handle();
    }
}
