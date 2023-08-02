using UnityEngine;

internal sealed class ThemePanelController
{
    private ThemePanelView _themePanelView;
    private GameObject _themePanelPrefab;
    public ThemePanelController()
    {
        _themePanelPrefab = Resources.Load<GameObject>("Prefabs/UI/ThemePanelCanvas");
        _themePanelView = GameObject.FindObjectOfType<ThemePanelView>();
    }
    public void ShowThemePanel()
    {
        if (_themePanelView == null)
        {
            GameObject go = GameObject.Instantiate(_themePanelPrefab);
            _themePanelView = go.GetComponent<ThemePanelView>();
            _themePanelView.closeThemePanelButton.onClick.AddListener(ClosePanel);
        }
    }
    private void ClosePanel()
    {
        GameObject.Destroy(_themePanelView.gameObject);
    }
}
