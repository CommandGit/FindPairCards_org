using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardScaleController : IUpdate
{
    private Card _cardModel;
    private CardView _cardView;
    public CardScaleController(Card cardModel, CardView cardView)
    {
        _cardModel = cardModel;
        _cardView = cardView;
    }

    public void Update(float deltaTime)
    {
        float newScale = Mathf.MoveTowards(_cardModel.CurrentScale, _cardModel.TargetScale, 4f * deltaTime);
        _cardModel.CurrentScale = newScale;
        Vector3 scale = new Vector3(newScale, 1.5f * newScale, newScale);
        _cardView.transform.localScale = scale;
    }
}
