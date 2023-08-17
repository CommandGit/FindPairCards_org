
internal sealed class SoundManager
{
    private SoundController _soundController;

    public SoundManager()
    {
        _soundController = new SoundController();
    }

    public void OnCardRotateStarted(Card card, CardView cardView)
    {
        if (card.TargetYAngle == 180f)
            _soundController.PlayOnParent("Sound/RotateCardFaceUp", 1f, cardView.transform);
        else
            _soundController.PlayOnParent("Sound/RotateCardFaceDown", 1f, cardView.transform);
    }
}
