internal sealed class CheckPairController : BaseEnabled
{
    public EventHandler<Card, CardView> TrueCardFinded = new EventHandler<Card, CardView>();
    public EventHandler<Card, CardView> FalseCardFinded = new EventHandler<Card, CardView>();

    public void OnPairFinded(CheckPairData checkPairData)
    {
        if (!_enable) return;

        if (checkPairData.card1.Number == checkPairData.card2.Number)
        {
            TrueCardFinded.Handle(checkPairData.card1, checkPairData.cardView1);
            TrueCardFinded.Handle(checkPairData.card2, checkPairData.cardView2);
        }
        else
        {
            FalseCardFinded.Handle(checkPairData.card1, checkPairData.cardView1);
            FalseCardFinded.Handle(checkPairData.card2, checkPairData.cardView2);
        }
    }
}
