using System.Collections;
using System.Collections.Generic;
using UnityEngine;
internal sealed class Menu 
{
    private UpdateController _updateController;

    public void Start()
    {
        EventHandler OnStartGame = new EventHandler();
        _updateController = new UpdateController();

        SettingsController settingsController = new SettingsController();
        Settings settings = settingsController.GetSettings();

        MainMenuController mainMenuController = new MainMenuController();
        
        OnStartGame.AddHandler(mainMenuController.OnStartGame);

        SettingsPanelController settingsPanelController = new SettingsPanelController();
        mainMenuController.OnSettingPressed.AddHandler(settingsPanelController.ShowSettings);

        ThemePanelController themePanelController = new ThemePanelController();
        mainMenuController.OnThemePanelPressed.AddHandler(themePanelController.ShowThemePanel);

        LevelMenuController levelMenuController = new LevelMenuController();
        mainMenuController.OnNewGameButtonPressed.AddHandler(levelMenuController.ShowLevelMenu);

        LevelLoader levelLoader = new LevelLoader(settings);
        levelMenuController.LevelButtonPressed.AddHandler(levelLoader.LoadLevel);

        BackgroundMusicController backgroundMusicController = new BackgroundMusicController();
        _updateController.Add(backgroundMusicController);
        OnStartGame.AddHandler(backgroundMusicController.PlayMenuBackgroundRandom);

        OnStartGame.Handle();

    }
    public void Update(float deltaTime)
    {
        _updateController.Update(deltaTime);
    }
}
