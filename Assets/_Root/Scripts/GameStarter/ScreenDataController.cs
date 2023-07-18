using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class ScreenDataController
{
    public EventHandler<ScreenData> OnScreenDataChanged;

    private ScreenData _screenData;

    public ScreenDataController()
    {
        _screenData = new ScreenData();
        OnScreenDataChanged = new EventHandler<ScreenData>();
    }

    public void OnScreenResolutionChanged(int screenWidth, int screenHeight)
    {
        _screenData.ZoneSettings.FullScreen = new ZoneSettings(0, 0, 1, 1);
        _screenData.ZoneSettings.Cards = new ZoneSettings(0, 0.1f, 1, 1);

        _screenData.ZoneSettings.Pause = new ZoneSettings(0.8f, 2 / 3f, 1, 1);
        _screenData.ZoneSettings.Timer = new ZoneSettings(0.8f, 1 / 3f, 1, 2 / 3f);
        _screenData.ZoneSettings.Level = new ZoneSettings(0.8f, 0, 1, 1 / 3f);

        UpdateZonePosition(_screenData.ZonePositions.FullScreen, _screenData.ZoneSettings.FullScreen);
        UpdateZonePosition(_screenData.ZonePositions.Cards, _screenData.ZoneSettings.Cards);
        UpdateZonePosition(_screenData.ZonePositions.Pause, _screenData.ZoneSettings.Pause);
        UpdateZonePosition(_screenData.ZonePositions.Timer, _screenData.ZoneSettings.Timer);
        UpdateZonePosition(_screenData.ZonePositions.Level, _screenData.ZoneSettings.Level);

        OnScreenDataChanged.Handle(_screenData);
    }

    private void UpdateZonePosition(ZonePosition position, ZoneSettings settings)
    {
        position.MinPosition = Camera.main.ScreenToWorldPoint(new Vector3(settings.MinPosition.x * Screen.width, settings.MinPosition.y * Screen.height, 10f));
        position.MaxPosition = Camera.main.ScreenToWorldPoint(new Vector3(settings.MaxPosition.x * Screen.width, settings.MaxPosition.y * Screen.height, 10f));
    }
}
