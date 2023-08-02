using System;
using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class MainMenuController
{
    public EventHandler OnSettingPressed = new EventHandler();
    public EventHandler OnThemePanelPressed = new EventHandler();
    public EventHandler OnNewGameButtonPressed = new EventHandler();


    private GameObject _mainMenuPrefab;
    private GameObject _settingsPanelPrefab;
    private MainMenuView _mainMenuView;
    private SettingsPanelView _settingsPanelView;
    private SettingsPanelModelSettings _settingsPanelModelSettings;
    public MainMenuController()
    {
        _mainMenuPrefab = Resources.Load<GameObject>("Prefabs/UI/Menu");
    }
    public void OnStartGame()
    {
        Show();
        _mainMenuView.newGameButton.onClick.AddListener(StartNewGame);
        _mainMenuView.settingsButton.onClick.AddListener(ShowSettingsEnabled);
        _mainMenuView.chooseThemeButton.onClick.AddListener(ShowThemePanelEnabled);
        _mainMenuView.exitGameButton.onClick.AddListener(ExitApplication);
    }
    private void Show()
    {
        GameObject go = GameObject.Instantiate(_mainMenuPrefab);
        _mainMenuView = go.GetComponent<MainMenuView>();
    }
    private void StartNewGame()
    {
        OnNewGameButtonPressed.Handle();
    }
    private void ShowSettingsEnabled()
    {
        OnSettingPressed.Handle();
    }
    private void ShowThemePanelEnabled()
    {
        OnThemePanelPressed.Handle();
    }
    private void LoadLevelMenuPanel()
    {
        OnNewGameButtonPressed.Handle();
    }
    private void ExitApplication()
    {
        Application.Quit();
        Debug.Log("app quit");
    }
   
    

}
