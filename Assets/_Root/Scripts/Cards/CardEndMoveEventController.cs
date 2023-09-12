using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardEndMoveEventController : IUpdate
{
    public EventHandler<Card, CardView> OnEndMove = new EventHandler<Card, CardView>();

    private Card _cardModel;
    private CardView _cardView;
    private bool _isOnTarget;
    public CardEndMoveEventController(Card cardModel, CardView cardView)
    {
        _cardModel = cardModel;
        _cardView = cardView;
        _isOnTarget = false;
    }

    public void Update(float deltaTime)
    {
        if (_cardView.Transform.position == _cardModel.TargetPosition)
        {
            if (_isOnTarget) return;

            _isOnTarget = true;
            OnEndMove.Handle(_cardModel, _cardView);
        }
        else
        {
            _isOnTarget = false;
        }
    }
}
