
internal sealed class NeedPreviewCardsChecker
{
    public EventHandler OnNeedPreview = new EventHandler();
    public EventHandler OnNoNeedPreview = new EventHandler();

    private LevelSettings _levelSettings;

    public NeedPreviewCardsChecker(LevelSettings levelSettings)
    {
        _levelSettings = levelSettings;
    }

    public void Check()
    {
        if (_levelSettings.PreviewCards)
        {
            OnNeedPreview.Handle();
        }
        else
        {
            OnNoNeedPreview.Handle();
        }
    }
}
