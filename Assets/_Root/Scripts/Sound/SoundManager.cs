
internal sealed class SoundManager
{
    private SoundController _soundController;

    public SoundManager()
    {
        _soundController = new SoundController();
    }

    public void OnCardRotateStarted(Card card, CardView cardView)
    {
        _soundController.PlayOnParent("Sound/Rotate", cardView.transform);
        //_soundController.Play("Sound/Rotate");
    }
}
