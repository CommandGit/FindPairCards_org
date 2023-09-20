using StopWatch;

internal sealed class Game
{
    private UpdateController _updateController;

    public void Start()
    {
        _updateController = new UpdateController();

        EventHandler OnStartScene = new EventHandler();

        SettingsController settingsController = new SettingsController();
        Settings settings = settingsController.GetSettings();

        TableMainController tableMainController = new TableMainController();
        OnStartScene.AddHandler(tableMainController.OnStartScene);

        ScreenResolutionController screenResolutionController = new ScreenResolutionController();
        _updateController.Add(screenResolutionController);
        OnStartScene.AddHandler(screenResolutionController.OnStartScene);

        ScreenDataController screenDataController = new ScreenDataController();
        screenResolutionController.OnSreenResolutionChanged.AddHandler(screenDataController.OnScreenResolutionChanged);
        screenDataController.OnScreenDataChanged.AddHandler(tableMainController.OnScreenDataChanged);

        CardManager cardManager = new CardManager(_updateController, settings.LevelSettings);
        OnStartScene.AddHandler(cardManager.OnStartScene);
        screenDataController.OnScreenDataChanged.AddHandler(cardManager.OnScreenDataChanged);

        WinGameController winGameController = new WinGameController();
        cardManager.OnCardsCountChanged.AddHandler(winGameController.OnCardsCountChanged);

        PauseManager pauseManager = new PauseManager();
        _updateController.Add(pauseManager);
        winGameController.OnWinGame.AddHandler(pauseManager.OnWinGame);
        cardManager.OnReadyToPlay.AddHandler(pauseManager.Enable);

        WinGameUIInstantiator winGameUIInstantiator = new WinGameUIInstantiator();
        winGameController.OnWinGame.AddHandler(winGameUIInstantiator.Instantiate);

        MouseClickController mouseClickController = new MouseClickController();
        _updateController.Add(mouseClickController);
        cardManager.OnReadyToPlay.AddHandler(mouseClickController.Enable);
        pauseManager.OnPauseEnable.AddHandler(mouseClickController.Disable);
        pauseManager.OnPauseDisable.AddHandler(mouseClickController.Enable);

        StopWatchController stopWatchController = new StopWatchController();
        _updateController.Add(stopWatchController);
        OnStartScene.AddHandler(stopWatchController.Reset);
        OnStartScene.AddHandler(stopWatchController.Show);
        OnStartScene.AddHandler(stopWatchController.Disable);
        cardManager.OnFirstCardClicked.AddHandler(stopWatchController.Enable);
        cardManager.OnFirstCardClicked.AddHandler(stopWatchController.Start);
        winGameController.OnWinGame.AddHandler(stopWatchController.Stop);
        pauseManager.OnPauseEnable.AddHandler(stopWatchController.Stop);
        pauseManager.OnPauseDisable.AddHandler(stopWatchController.Start);

        PauseMenuController pauseMenu = new PauseMenuController();
        pauseManager.OnPauseEnable.AddHandler(pauseMenu.Show);
        pauseManager.OnPauseDisable.AddHandler(pauseMenu.Hide);

        SoundManager soundManager = new SoundManager();
        cardManager.OnCardRotateStarted.AddHandler(soundManager.OnCardRotateStarted);
        cardManager.OnCardEndMove.AddHandler(soundManager.OnCardEndMove);
        cardManager.OnStartOpenPreviewCards.AddHandler(soundManager.OnStartOpenPreviewCards);
        cardManager.OnStartClosePreviewCards.AddHandler(soundManager.OnStartClosePreviewCards);

        BackgroundMusicController backgroundMusicController = new BackgroundMusicController();
        _updateController.Add(backgroundMusicController);
        OnStartScene.AddHandler(backgroundMusicController.PlayGameBackgroundRandom);

        SettingsChangeController settingsChangeController = new SettingsChangeController(settings);
        OnStartScene.AddHandler(settingsChangeController.OnStartScene);

        AudioMixerController audioMixerController = new AudioMixerController();
        settingsChangeController.OnSoundSettingsChanged.AddHandler(audioMixerController.OnChangeSettings);

        OnStartScene.Handle();
    }

    public void Update(float deltaTime)
    {
        _updateController.Update(deltaTime);
    }
}
