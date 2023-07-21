using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class PauseUIController : BaseEnabled, IUpdate
{
    public EventHandler<bool> OnPauseChanged;
    private GameObject _pauseUIGameObject;
    private GameObject _pauseUIPrefab;
    private bool _isGamePaused;

    public PauseUIController() : base()
    {
        OnPauseChanged = new EventHandler<bool>();
        _isGamePaused = false;
        _pauseUIGameObject = null;
        _pauseUIPrefab = Resources.Load<GameObject>("Prefabs/UI/PauseGameCanvas");
    }

    public void Update(float deltaTime)
    {
        if (!_enable) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePause(!_isGamePaused);
        }
    }

    public void OnWinGame()
    {
        ChangePause(false);
        _enable = false;
    }

    private void ChangePause(bool newPauseValue)
    {
        _isGamePaused = newPauseValue;
        OnPauseChanged.Handle(_isGamePaused);
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (_isGamePaused)
        {
            if (_pauseUIGameObject == null)
            {
                _pauseUIGameObject = GameObject.Instantiate(_pauseUIPrefab);
            }
            
        }
        else
        {
            if (_pauseUIGameObject != null)
            {
                GameObject.Destroy(_pauseUIGameObject);
            }
        }
        
    }
}
