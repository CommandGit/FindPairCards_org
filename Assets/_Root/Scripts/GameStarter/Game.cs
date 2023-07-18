using StopWatch;
using System.Collections.Generic;
using UnityEngine;

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

        PauseUIController pauseUIController = new PauseUIController();
        _updateController.Add(pauseUIController);
        OnStartGame.AddHandler(pauseUIController.Enable);
        winGameController.OnWinGame.AddHandler(pauseUIController.OnWinGame);

        WinGameUIInstantiator winGameUIInstantiator = new WinGameUIInstantiator();
        winGameController.OnWinGame.AddHandler(winGameUIInstantiator.Instantiate);

        MouseClickController mouseClickController = new MouseClickController();
        _updateController.Add(mouseClickController);
        cardManager.BeforeCardsPrevievStart.AddHandler(mouseClickController.Disable);
        cardManager.AfterCardsPrevievComplete.AddHandler(mouseClickController.Enable);
        pauseUIController.OnPauseChanged.AddHandler(mouseClickController.OnPauseChanged);

        StopWatchController stopWatchController = new StopWatchController();
        _updateController.Add(stopWatchController);
        OnStartGame.AddHandler(stopWatchController.Reset);
        OnStartGame.AddHandler(stopWatchController.Show);
        cardManager.OnFirstCardClicked.AddHandler(stopWatchController.Start);
        winGameController.OnWinGame.AddHandler(stopWatchController.Stop);

        OnStartGame.Handle();
    }

    public void Update(float deltaTime)
    {
        _updateController.Update(deltaTime);
    }
}
