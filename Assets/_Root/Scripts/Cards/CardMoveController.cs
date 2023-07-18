using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardMoveController : IUpdate
{
    private Card _cardModel;
    private CardView _cardView;
    public CardMoveController(Card cardModel, CardView cardView)
    {
        _cardModel = cardModel;
        _cardView = cardView;
    }

    public void Update(float deltaTime)
    {
        Vector3 newPosition = Vector3.MoveTowards(_cardView.Transform.position, _cardModel.TargetPosition, 50f * deltaTime);
        _cardView.transform.position = newPosition;
    }
}
