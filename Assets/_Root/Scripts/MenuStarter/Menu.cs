using System.Collections;
using System.Collections.Generic;
using UnityEngine;
internal sealed class Menu 
{
    private UpdateController _updateController;

    public void Start()
    {
        _updateController = new UpdateController();
        EventHandler OnStartGame = new EventHandler();

        MainMenuController mainMenuController = new MainMenuController();
        
        OnStartGame.AddHandler(mainMenuController.OnStartGame);

        SettingsPanelController settingsPanelController = new SettingsPanelController();
        _updateController.Add(settingsPanelController);
        OnStartGame.AddHandler(settingsPanelController.OnStartGame);


        OnStartGame.Handle();

    }
    public void Update(float deltaTime)
    {
        _updateController.Update(deltaTime);
    }
}
