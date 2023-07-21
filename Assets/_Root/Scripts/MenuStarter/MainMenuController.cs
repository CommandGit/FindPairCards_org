using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class MainMenuController 
{
    private GameObject _mainMenuPrefab;
    private GameObject _mainMenuObject;
    private MainMenuView _mainMenuView;
    public MainMenuController()
    {
        _mainMenuPrefab = Resources.Load<GameObject>("Prefabs/UI/Menu");
        _mainMenuView = _mainMenuPrefab.GetComponent<MainMenuView>();
    }
    public void OnStartGame()
    {
        Show();
        _mainMenuView.newGameButton.onClick.AddListener(StartNewGame);
    }

    private void Show()
    {
        _mainMenuObject = GameObject.Instantiate(_mainMenuPrefab);

    }
    private void StartNewGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("dd");
    }
}
