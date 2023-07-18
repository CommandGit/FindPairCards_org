using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardRotateCompleteController : BaseEnabled, IUpdate
{
    public EventHandler<Card, CardView> OnCardRotateComplete = new EventHandler<Card, CardView>();

    private Card _card;
    private CardView _cardView;
    private float _lastYAngle;

    public CardRotateCompleteController(Card card, CardView cardView) : base()
    {
        _card = card;
        _cardView = cardView;
        _lastYAngle = 0;
        _enable = true;
    }

    public void Update(float deltaTime)
    {
        if (!_enable) return;

        if (_card.CurrentYAngle != _lastYAngle && _card.CurrentYAngle == _card.TargetYAngle)
        {
            OnCardRotateComplete.Handle(_card, _cardView);
        }

        _lastYAngle = _card.CurrentYAngle;
    }
}

internal sealed class CardsRotateCompleteController
{
    public EventHandler<Card, CardView> OnCardRotateComplete = new EventHandler<Card, CardView>();

    private UpdateController _updateController;

    public CardsRotateCompleteController(UpdateController updateController)
    {
        _updateController = updateController;
    }

    public void OnCardInstantiated(Card cardModel, CardView cardView)
    {
        CardRotateCompleteController cardRotateCompleteController  = new CardRotateCompleteController(cardModel, cardView);
        _updateController.AddToView(cardRotateCompleteController, cardView);
        cardRotateCompleteController.OnCardRotateComplete.AddHandler(OnCardRotateComplete.Handle);
    }
}