using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class MainMenuController 
{
    private GameObject _mainMenuPrefab;
    private GameObject _settingsPanelPrefab;
    private MainMenuView _mainMenuView;
    private SettingsPanelView _settingsPanelView;
    public MainMenuController()
    {
        _mainMenuPrefab = Resources.Load<GameObject>("Prefabs/UI/Menu");
        _settingsPanelPrefab = Resources.Load<GameObject>("Prefabs/UI/SettingsPanel");
    }
    public void OnStartGame()
    {
        Show();
        _mainMenuView.newGameButton.onClick.AddListener(StartNewGame);
        _mainMenuView.settingsButton.onClick.AddListener(ShowSettings);
        _mainMenuView.exitGameButton.onClick.AddListener(ExitApplication);
    }
    private void Show()
    {
        GameObject go = GameObject.Instantiate(_mainMenuPrefab);
        _mainMenuView = go.GetComponent<MainMenuView>();
    }

    private void ExitApplication()
    {
        Application.Quit();
        Debug.Log("app quit");
    }
    private void ShowSettings()
    {
        GameObject go = GameObject.Instantiate(_settingsPanelPrefab);
        _settingsPanelView = go.GetComponent<SettingsPanelView>();
    }
    private void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }
    
}
