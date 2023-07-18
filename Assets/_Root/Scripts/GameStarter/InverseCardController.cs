using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

internal sealed class InverseCardController
{
    public EventHandler<CheckPairData> OnPairFinded = new EventHandler<CheckPairData>();

    private List<Card> _inversedCardModels;
    private List<CardView> _inversedCardViews;

    public InverseCardController()
    {
        _inversedCardModels = new List<Card>();
        _inversedCardViews = new List<CardView>();
    }

    private void CheckCount()
    {
        if (_inversedCardModels.Count < 2) return;

        CheckPairData checkPairData = new CheckPairData();
        checkPairData.card1 = _inversedCardModels[0];
        checkPairData.cardView1 = _inversedCardViews[0];
        checkPairData.card2 = _inversedCardModels[1];
        checkPairData.cardView2 = _inversedCardViews[1];

        OnPairFinded.Handle(checkPairData);
    }

    private void AddCard(Card card, CardView cardView)
    {
        int index = _inversedCardModels.IndexOf(card);
        if (index == -1)
        {
            _inversedCardModels.Add(card);
            _inversedCardViews.Add(cardView);
            CheckCount();
        }
    }

    private void RemoveCard(Card card, CardView cardView)
    {
        int index = _inversedCardModels.IndexOf(card);
        if (index != -1)
        {
            _inversedCardModels.RemoveAt(index);
            _inversedCardViews.RemoveAt(index);
        }
    }

    public void OnDestroyCard(Card card, CardView cardView)
    {
        RemoveCard(card, cardView);
    }

    public void OnCardRotateStarted(Card card, CardView cardView)
    {
        RemoveCard(card, cardView);
    }

    public void OnCardRotateComplete(Card card, CardView cardView)
    {
        if (card.CurrentYAngle == 180f)
        {
            AddCard(card, cardView);
        }
        else
        {
            RemoveCard(card, cardView);
        }
    }
}

internal sealed class CheckPairData
{
    public Card card1;
    public CardView cardView1;
    public Card card2;
    public CardView cardView2;
}