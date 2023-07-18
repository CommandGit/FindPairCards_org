using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class FirstCardClickEventController
{
    public EventHandler OnFirstCardClicked = new EventHandler();

    private bool _isFirstCardClicked = false;

    public void OnCardClick(Card card, CardView cardView)
    {
        if (_isFirstCardClicked) return;

        _isFirstCardClicked = true;
        OnFirstCardClicked.Handle();
    }
}
