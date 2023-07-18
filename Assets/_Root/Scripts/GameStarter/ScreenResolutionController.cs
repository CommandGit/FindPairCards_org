
using System;
using UnityEngine;

internal sealed class ScreenResolutionController : IUpdate
{
    public EventHandler<int, int> OnSreenResolutionChanged;

    private int _screenWidth;
    private int _screenHeight;

    public ScreenResolutionController()
    {
        _screenWidth = 0;
        _screenHeight = 0;
        OnSreenResolutionChanged = new EventHandler<int, int>();
    }

    public void OnStartGame()
    {
        ChangeScreenParams(Screen.width, Screen.height);
    }

    private void ChangeScreenParams(int screenWidth, int screenHeight)
    {
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;
        OnSreenResolutionChanged.Handle(_screenWidth, _screenHeight);
    }

    public void Update(float deltaTime)
    {
        if (_screenWidth != Screen.width || _screenHeight != Screen.height)
        {
            ChangeScreenParams(Screen.width, Screen.height);
        }
    }
}
