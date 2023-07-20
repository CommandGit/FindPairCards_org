using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class MainMenuController 
{
    private GameObject _mainMenuPrefab;
    private GameObject _mainMenuObject;

    public MainMenuController()
    {
        _mainMenuPrefab = Resources.Load<GameObject>("Prefabs/UI/Menu");
    }
    public void OnStartGame()
    {
        Show();
    }
    private void Show()
    {
        _mainMenuObject = GameObject.Instantiate(_mainMenuPrefab);
    }
}
