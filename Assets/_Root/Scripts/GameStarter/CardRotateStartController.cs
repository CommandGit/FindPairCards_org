using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardRotateStartController
{
    public EventHandler<Card, CardView> OnCardRotateStarted = new EventHandler<Card, CardView>();

    public void OnCardClick(Card card, CardView cardView)
    {
        StartRotate(card, cardView);
    }

    public void StartRotate(Card card, CardView cardView)
    {
        if (card.TargetYAngle == 0f)
        {
            card.TargetYAngle = 180f;
        }
        else if (card.TargetYAngle == 180f)
        {
            card.TargetYAngle = 0f;
        }

        OnCardRotateStarted.Handle(card, cardView);
    }
}
