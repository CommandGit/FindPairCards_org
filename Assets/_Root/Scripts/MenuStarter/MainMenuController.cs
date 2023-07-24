using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class MainMenuController : IUpdate
{
    private GameObject _mainMenuPrefab;
    private MainMenuView _mainMenuView;
    public MainMenuController()
    {
        _mainMenuPrefab = Resources.Load<GameObject>("Prefabs/UI/Menu");
    }
    public void OnStartGame()
    {
        Show();
    }

    public void Update(float deltaTime)
    {
        _mainMenuView.newGameButton.onClick.AddListener(StartNewGame);
    }

    private void Show()
    {
        _mainMenuPrefab = GameObject.Instantiate(_mainMenuPrefab);
        _mainMenuView = _mainMenuPrefab.GetComponent<MainMenuView>();

    }
    private void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }
}
