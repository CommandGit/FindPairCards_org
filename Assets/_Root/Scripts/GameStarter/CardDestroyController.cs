using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardDestroyController
{
    public EventHandler<Card, CardView> OnDestroy = new EventHandler<Card, CardView>();

    private Card _card;
    private CardView _cardView;

    public CardDestroyController(Card card, CardView cardView)
    {
        _card = card;
        _cardView = cardView;
        _cardView.ActionOnDestroy += ViewOnDestroy;
    }

    private void ViewOnDestroy()
    {
        OnDestroy.Handle(_card, _cardView);
    }
}

internal sealed class CardsDestroyController
{
    public EventHandler<Card, CardView> OnDestroy = new EventHandler<Card, CardView>();

    public void OnCardInstantiated(Card card, CardView cardView)
    {
        CardDestroyController cardDestroyController = new CardDestroyController(card, cardView);
    }

    public void DestroyCard(Card card, CardView cardView)
    {
        GameObject.Destroy(cardView.gameObject);
        OnDestroy.Handle(card, cardView);
    }
}