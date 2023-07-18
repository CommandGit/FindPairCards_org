using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

internal sealed class CardClickController
{
    public EventHandler<Card, CardView> OnCardClick;

    private Card _cardModel;
    private CardView _cardView;

    public CardClickController(Card cardModel, CardView cardView)
    {
        _cardModel = cardModel;
        _cardView = cardView;
        _cardView.ActionOnClick += OnClick;
        OnCardClick = new EventHandler<Card, CardView>();
    }

    private void OnClick()
    {
        OnCardClick.Handle(_cardModel, _cardView);
    }
}

internal sealed class CardsClickController
{
    public EventHandler<Card, CardView> OnCardClick;

    public CardsClickController()
    {
        OnCardClick = new EventHandler<Card, CardView>();
    }

    public void OnCardInstantiated(Card cardModel, CardView cardView)
    {
        CardClickController cardClickController = new CardClickController(cardModel, cardView);
        cardClickController.OnCardClick.AddHandler(OnCardClick.Handle);
    }
}