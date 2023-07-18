using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardManager
{
    public EventHandler BeforeCardsPrevievStart;
    public EventHandler AfterCardsPrevievComplete;
    public EventHandler<int> OnCardsCountChanged;
    public EventHandler OnFirstCardClicked;

    private EventHandler _onStartGame;
    private EventHandler<ScreenData> _onScreenDataChanged;

    public CardManager(UpdateController updateController)
    {
        BeforeCardsPrevievStart = new EventHandler();
        AfterCardsPrevievComplete = new EventHandler();
        OnCardsCountChanged = new EventHandler<int>();
        OnFirstCardClicked = new EventHandler();

        _onStartGame = new EventHandler();
        _onScreenDataChanged = new EventHandler<ScreenData>();

        CardsInfo cardsInfo = new CardsInfo(16);
        _onScreenDataChanged.AddHandler(cardsInfo.OnScreenDataChanged);
        
        CardsDestroyController cardsDestroyController = new CardsDestroyController();
        cardsDestroyController.OnDestroy.AddHandler(cardsInfo.RemoveCard);

        CardsInstantiator cardsInstantiator = new CardsInstantiator(cardsInfo, updateController);
        _onStartGame.AddHandler(cardsInstantiator.InstantiateCards);
        cardsInstantiator.OnCardInstantiated.AddHandler(cardsDestroyController.OnCardInstantiated);

        CardsClickController cardsClickController = new CardsClickController();
        cardsInstantiator.OnCardInstantiated.AddHandler(cardsClickController.OnCardInstantiated);

        CardRotateStartController cardRotateStartController = new CardRotateStartController();
        cardsClickController.OnCardClick.AddHandler(cardRotateStartController.OnCardClick);

        CheckPairController checkPairController = new CheckPairController();
        checkPairController.TrueCardFinded.AddHandler(cardsDestroyController.DestroyCard);
        checkPairController.FalseCardFinded.AddHandler(cardRotateStartController.StartRotate);

        CardsRotateCompleteController cardsRotateCompleteController = new CardsRotateCompleteController(updateController);
        cardsInstantiator.OnCardInstantiated.AddHandler(cardsRotateCompleteController.OnCardInstantiated);

        PreviewCardsController previewCardsController = new PreviewCardsController(updateController, cardsInfo);
        _onScreenDataChanged.AddHandler(previewCardsController.OnScreenDataChanged);
        previewCardsController.BeforeStart.AddHandler(checkPairController.Disable);
        previewCardsController.BeforeStart.AddHandler(BeforeCardsPrevievStart.Handle);
        previewCardsController.OnComplete.AddHandler(checkPairController.Enable);
        previewCardsController.OnComplete.AddHandler(AfterCardsPrevievComplete.Handle);
        updateController.Add(previewCardsController);
        _onStartGame.AddHandler(previewCardsController.Start);

        CardsCountController cardsCountController = new CardsCountController();
        cardsInstantiator.OnCardInstantiated.AddHandler(cardsCountController.OnCardInstantiated);
        cardsDestroyController.OnDestroy.AddHandler(cardsCountController.OnCardDestroyed);
        cardsCountController.OnCardsCountChanged.AddHandler(OnCardsCountChanged.Handle);

        InverseCardController inverseCardController = new InverseCardController();
        cardsDestroyController.OnDestroy.AddHandler(inverseCardController.OnDestroyCard);
        cardRotateStartController.OnCardRotateStarted.AddHandler(inverseCardController.OnCardRotateStarted);
        cardsRotateCompleteController.OnCardRotateComplete.AddHandler(inverseCardController.OnCardRotateComplete);
        inverseCardController.OnPairFinded.AddHandler(checkPairController.OnPairFinded);

        FirstCardClickEventController firstCardClickEventController = new FirstCardClickEventController();
        cardsClickController.OnCardClick.AddHandler(firstCardClickEventController.OnCardClick);
        firstCardClickEventController.OnFirstCardClicked.AddHandler(OnFirstCardClicked.Handle);
    }

    public void OnStartGame()
    {
        _onStartGame.Handle();
    }

    public void OnScreenDataChanged(ScreenData screenData)
    {
        _onScreenDataChanged.Handle(screenData);
    }
}
