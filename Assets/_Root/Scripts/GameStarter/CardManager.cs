
internal sealed class CardManager
{
    public EventHandler OnReadyToPlay = new EventHandler();
    public EventHandler<int> OnCardsCountChanged = new EventHandler<int>();
    public EventHandler OnFirstCardClicked = new EventHandler();
    public EventHandler<Card, CardView> OnCardRotateStarted = new EventHandler<Card, CardView>();
    public EventHandler<Card, CardView> OnCardEndMove = new EventHandler<Card, CardView>();

    private CardsInfo _cardsInfo;
    private CardsDestroyController _cardsDestroyController;
    private CardsInstantiator _cardsInstantiator;
    private CardsClickController _cardsClickController;
    private CardRotateStartController _cardRotateStartController;
    private CheckPairController _checkPairController;
    private CardsRotateCompleteController _cardsRotateCompleteController;
    private PreviewCardsController _previewCardsController;
    private CardsCountController _cardsCountController;
    private InverseCardController _inverseCardController;
    private FirstCardClickEventController _firstCardClickEventController;

    public CardManager(UpdateController updateController, LevelSettings levelSettings)
    {
        _cardsInfo = new CardsInfo(levelSettings.LevelNumber);
        _cardsDestroyController = new CardsDestroyController();
        _cardsInstantiator = new CardsInstantiator(_cardsInfo, updateController);
        _cardsClickController = new CardsClickController();
        _cardRotateStartController = new CardRotateStartController();
        _checkPairController = new CheckPairController();
        _cardsRotateCompleteController = new CardsRotateCompleteController(updateController);
        _previewCardsController = new PreviewCardsController(updateController, _cardsInfo);
        _cardsCountController = new CardsCountController();
        _inverseCardController = new InverseCardController();
        _firstCardClickEventController = new FirstCardClickEventController();

        updateController.Add(_previewCardsController);
        _cardsDestroyController.OnDestroy.AddHandler(_cardsInfo.RemoveCard);
        _cardsInstantiator.OnCardInstantiated.AddHandler(_cardsDestroyController.OnCardInstantiated);
        _cardsInstantiator.OnCardInstantiated.AddHandler(_cardsClickController.OnCardInstantiated);
        _cardsInstantiator.OnCardInstantiated.AddHandler(_cardsRotateCompleteController.OnCardInstantiated);
        _cardsInstantiator.OnCardInstantiated.AddHandler(_cardsCountController.OnCardInstantiated);
        _cardsClickController.OnCardClick.AddHandler(_cardRotateStartController.OnCardClick);
        _cardsClickController.OnCardClick.AddHandler(_firstCardClickEventController.OnCardClick);
        _checkPairController.TrueCardFinded.AddHandler(_cardsDestroyController.DestroyCard);
        _checkPairController.FalseCardFinded.AddHandler(_cardRotateStartController.StartRotate);
        _previewCardsController.BeforeStart.AddHandler(_checkPairController.Disable);
        _previewCardsController.OnComplete.AddHandler(_checkPairController.Enable);
        _previewCardsController.OnComplete.AddHandler(OnReadyToPlay.Handle);
        _cardsDestroyController.OnDestroy.AddHandler(_cardsCountController.OnCardDestroyed);
        _cardsDestroyController.OnDestroy.AddHandler(_inverseCardController.OnDestroyCard);
        _cardsCountController.OnCardsCountChanged.AddHandler(OnCardsCountChanged.Handle);
        _cardRotateStartController.OnCardRotateStarted.AddHandler(_inverseCardController.OnCardRotateStarted);
        _cardRotateStartController.OnCardRotateStarted.AddHandler(OnCardRotateStarted.Handle);
        _cardsRotateCompleteController.OnCardRotateComplete.AddHandler(_inverseCardController.OnCardRotateComplete);
        _inverseCardController.OnPairFinded.AddHandler(_checkPairController.OnPairFinded);
        _firstCardClickEventController.OnFirstCardClicked.AddHandler(OnFirstCardClicked.Handle);
    }

    public void OnStartScene()
    {
        _cardsInstantiator.InstantiateCards(OnCardEndMove);
        _previewCardsController.Start();
    }

    public void OnScreenDataChanged(ScreenData screenData)
    {
        _cardsInfo.OnScreenDataChanged(screenData);
        _previewCardsController.OnScreenDataChanged(screenData);
    }
}
