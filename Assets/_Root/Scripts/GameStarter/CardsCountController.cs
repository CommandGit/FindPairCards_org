using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardsCountController
{
    public EventHandler<int> OnCardsCountChanged = new EventHandler<int>();

    private int _cardsCount = 0;

    public void OnCardInstantiated(Card card, CardView cardView)
    {
        ChangeCount(_cardsCount + 1);
    }

    public void OnCardDestroyed(Card card, CardView cardView)
    {
        ChangeCount(_cardsCount - 1);
    }

    private void ChangeCount(int newValue)
    {
        _cardsCount = newValue;
        OnCardsCountChanged.Handle(_cardsCount);
    }
}
