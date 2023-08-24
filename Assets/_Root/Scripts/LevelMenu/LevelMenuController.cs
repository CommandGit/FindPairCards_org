using UnityEngine;

internal sealed class LevelMenuController
{
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
        }
    }
    private void ClosePanel()
    {
        GameObject.Destroy(_levelMenuView.gameObject);
    }

}
