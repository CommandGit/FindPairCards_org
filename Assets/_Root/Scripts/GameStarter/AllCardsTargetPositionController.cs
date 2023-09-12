
using System.Collections.Generic;

internal sealed class AllCardsTargetPositionController : BaseEnabled, IUpdate
{
    public EventHandler OnAllCardsOnTarget = new EventHandler();

    private List<Card> _cardModels = new List<Card>();
    private List<CardView> _cardViews = new List<CardView>();

    public void OnCardInstantiated(Card card, CardView cardView)
    {
        _cardModels.Add(card);
        _cardViews.Add(cardView);
    }

    private bool Check()
    {
        for (int i = 0; i < _cardModels.Count; i++)
        {
            Card currentCardModel = _cardModels[i];

            if (currentCardModel == null) continue;

            CardView currentCardView = _cardViews[i];

            if (currentCardModel.TargetPosition != currentCardView.transform.position) return false;
        }
        return true;
    }

    public void Update(float deltaTime)
    {
        if (!_enable) return;

        if (Check()) OnAllCardsOnTarget.Handle();
    }
}
