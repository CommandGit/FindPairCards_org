using System;
using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class MainMenuController:BaseEnabled
{
    public EventHandler OnSettingPressed = new EventHandler();

    private GameObject _mainMenuPrefab;
    private GameObject _settingsPanelPrefab;
    private MainMenuView _mainMenuView;
    private SettingsPanelView _settingsPanelView;
    private SettingsPanelModelSettings _settingsPanelModelSettings;
    public MainMenuController()
    {
        _mainMenuPrefab = Resources.Load<GameObject>("Prefabs/UI/Menu");
        _settingsPanelModelSettings = Resources.Load<SettingsPanelModelSettings>("ScriptableObject/SettingsPanelModelSettings");
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
        SceneManager.LoadScene(1);
    }
    private void ShowSettingsEnabled()
    {
        //_settingsPanelModelSettings.IsEnable = true;
        OnSettingPressed.Handle();
    }
    private void ShowThemePanelEnabled()
    {
        Debug.Log("ShowThemePanelEnabled");
    }
    private void ExitApplication()
    {
        Application.Quit();
        Debug.Log("app quit");
    }
   
    

}
