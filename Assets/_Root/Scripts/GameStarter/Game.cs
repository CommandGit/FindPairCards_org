using StopWatch;

internal sealed class Game
{
    private UpdateController _updateController;

    public void Start()
    {
        _updateController = new UpdateController();

        EventHandler OnStartGame = new EventHandler();

        TableMainController tableMainController = new TableMainController();
        OnStartGame.AddHandler(tableMainController.OnStartGame);

        ScreenResolutionController screenResolutionController = new ScreenResolutionController();
        _updateController.Add(screenResolutionController);
        OnStartGame.AddHandler(screenResolutionController.OnStartGame);

        ScreenDataController screenDataController = new ScreenDataController();
        screenResolutionController.OnSreenResolutionChanged.AddHandler(screenDataController.OnScreenResolutionChanged);
        screenDataController.OnScreenDataChanged.AddHandler(tableMainController.OnScreenDataChanged);

        CardManager cardManager = new CardManager(_updateController);
        OnStartGame.AddHandler(cardManager.OnStartGame);
        screenDataController.OnScreenDataChanged.AddHandler(cardManager.OnScreenDataChanged);

        WinGameController winGameController = new WinGameController();
        cardManager.OnCardsCountChanged.AddHandler(winGameController.OnCardsCountChanged);

        PauseManager pauseManager = new PauseManager();
        _updateController.Add(pauseManager);
        OnStartGame.AddHandler(pauseManager.OnStartGame);
        winGameController.OnWinGame.AddHandler(pauseManager.OnWinGame);

        WinGameUIInstantiator winGameUIInstantiator = new WinGameUIInstantiator();
        winGameController.OnWinGame.AddHandler(winGameUIInstantiator.Instantiate);

        MouseClickController mouseClickController = new MouseClickController();
        _updateController.Add(mouseClickController);
        cardManager.BeforeCardsPrevievStart.AddHandler(mouseClickController.Disable);
        cardManager.AfterCardsPrevievComplete.AddHandler(mouseClickController.Enable);
        pauseManager.OnPauseChanged.AddHandler(mouseClickController.OnPauseChanged);

        StopWatchController stopWatchController = new StopWatchController();
        _updateController.Add(stopWatchController);
        OnStartGame.AddHandler(stopWatchController.Reset);
        OnStartGame.AddHandler(stopWatchController.Show);
        cardManager.OnFirstCardClicked.AddHandler(stopWatchController.Start);
        winGameController.OnWinGame.AddHandler(stopWatchController.Stop);

        PauseMenu pauseMenu = new PauseMenu();
        pauseManager.OnPauseChanged.AddHandler(pauseMenu.OnPauseChanged);

        OnStartGame.Handle();
    }

    public void Update(float deltaTime)
    {
        _updateController.Update(deltaTime);
    }
}
