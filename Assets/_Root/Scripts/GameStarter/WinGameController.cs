using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class WinGameController
{
    public EventHandler OnWinGame;

    public WinGameController()
    {
        OnWinGame = new EventHandler();
    }

    public void OnCardsCountChanged(int cardsCount)
    {
        if (cardsCount == 0) OnWinGame.Handle();
    }
}
