using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardRotateController : IUpdate
{
    private Card _cardModel;
    private CardView _cardView;

    public CardRotateController(Card cardModel, CardView cardView)
    {
        _cardModel = cardModel;
        _cardView = cardView;
    }

    public void Update(float deltaTime)
    {
        float newAngle = Mathf.MoveTowards(_cardModel.CurrentYAngle, _cardModel.TargetYAngle, 360f * deltaTime);
        if (newAngle == _cardModel.CurrentYAngle) return;

        _cardModel.CurrentYAngle = newAngle;
        _cardView.YRotator.localRotation = Quaternion.Euler(0, newAngle, 0);

        float newZPosition = Mathf.Sin(Mathf.PI * newAngle / 180f) / 2f;
        Vector3 ZPosition = _cardView.ZTransform.localPosition;
        ZPosition.z = -newZPosition;
        _cardView.ZTransform.localPosition = ZPosition;
    }
}
