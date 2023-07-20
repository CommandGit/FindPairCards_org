using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardsInstantiator
{
    public EventHandler<Card, CardView> OnCardInstantiated;
    private CardsInfo _cardsInfo;
    private GameObject _prefab;
    private UpdateController _updateController;

    public CardsInstantiator(CardsInfo cardsInfo, UpdateController updateController)
    {
        _prefab = Resources.Load<GameObject>("Prefabs/PlayingGameObjects/Card");
        _cardsInfo = cardsInfo;
        OnCardInstantiated = new EventHandler<Card, CardView>();
        _updateController = updateController;
    }

    public void InstantiateCards()
    {
        foreach (Card card in _cardsInfo.Cards)
        {
            if (card == null) continue;

            GameObject go = GameObject.Instantiate(_prefab, card.StartPosition, Quaternion.identity);
            CardView cardView = go.GetComponent<CardView>();
            cardView.NumberText.text = card.Number.ToString();

            CardMoveController cardMoveController = new CardMoveController(card, cardView);
            _updateController.AddToView(cardMoveController, cardView);

            CardScaleController cardScaleController = new CardScaleController(card, cardView);
            _updateController.AddToView(cardScaleController, cardView);

            CardRotateController cardRotateController = new CardRotateController(card, cardView);
            _updateController.AddToView(cardRotateController, cardView);

            OnCardInstantiated.Handle(card, cardView);
        }
    }
}
