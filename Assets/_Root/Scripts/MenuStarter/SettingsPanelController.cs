using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class SettingsPanelController 
{
    private SettingsPanelView _settingsPanelView;

    public SettingsPanelController()
    {
        _settingsPanelView = GameObject.FindObjectOfType<SettingsPanelView>();
    }

    public void OnStartController()
    {
        _settingsPanelView.closeSettingsPanelButton.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
       _settingsPanelView.settingsPanelObject.SetActive(false);
    }
}
