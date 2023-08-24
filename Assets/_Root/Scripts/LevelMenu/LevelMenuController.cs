using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal sealed class LevelMenuController
{
    public EventHandler<int> LevelButtonPressed = new EventHandler<int>();

    private LevelMenuView _levelMenuView;
    private GameObject _levelMenuPrefab;

    public LevelMenuController()
    {
        _levelMenuPrefab = Resources.Load<GameObject>("Prefabs/UI/LevelMenuCanvas");
        _levelMenuView = GameObject.FindObjectOfType<LevelMenuView>();
    }
    public void ShowLevelMenu()
    {
        if( _levelMenuView == null )
        {
            GameObject go = GameObject.Instantiate(_levelMenuPrefab);
            _levelMenuView = go.GetComponent<LevelMenuView>();
            _levelMenuView.backToMenuButton.onClick.AddListener(ClosePanel);
            InitButtonText();
            InitLevelButtonHandlers();
        }
    }
    private void ClosePanel()
    {
        GameObject.Destroy(_levelMenuView.gameObject);
    }

    private void InitButtonText()
    {
        for (int i = 0; i < _levelMenuView.levelButtons.Count; i++)
        {
            Button button = _levelMenuView.levelButtons[i];
            TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
            buttonText.text = (i + 1).ToString();
        }
    }

    private void InitLevelButtonHandlers()
    {
        for (int i = 0; i < _levelMenuView.levelButtons.Count; i++)
        {
            Button button = _levelMenuView.levelButtons[i];
            LevelButtonClickController buttonClickController = new LevelButtonClickController(button, i + 1, OnLevelButtonPressed);
            button.onClick.AddListener(buttonClickController.OnClick);
        }
    }
    private void OnLevelButtonPressed(Button button, int buttonLevel)
    {
        ClosePanel();
        LevelButtonPressed.Handle(buttonLevel);
    }

}

internal sealed class LevelButtonClickController
{
    private Button _button;
    private Action<Button, int> _action;
    private int _buttonLevel;
    public LevelButtonClickController(Button Button, int ButtonLevel, Action<Button, int> Action)
    {
        _button = Button;
        _buttonLevel = ButtonLevel;
        _action = Action;
    }

    public void OnClick()
    {
        _action.Invoke(_button, _buttonLevel);
    }
}