using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class TableMainController
{
    private GameObject _prefab;
    private GameObject _tableGameObject;
    private ZonePosition _tableZonePosition;
    public TableMainController()
    {
        _prefab = Resources.Load<GameObject>("Prefabs/PlayingGameObjects/Table");
        _tableZonePosition = null;
    }

    public void OnStartScene()
    {
        Show();
    }

    private void Show()
    {
        _tableGameObject = GameObject.Instantiate(_prefab);
    }

    private void UpdateTransform()
    {
        float centerX = MathF.Abs(_tableZonePosition.MinPosition.x + _tableZonePosition.MaxPosition.x) / 2f;
        float centerY = MathF.Abs(_tableZonePosition.MinPosition.y + _tableZonePosition.MaxPosition.y) / 2f;

        float scaleX = MathF.Abs(_tableZonePosition.MinPosition.x - _tableZonePosition.MaxPosition.x);
        float scaleY = MathF.Abs(_tableZonePosition.MinPosition.y - _tableZonePosition.MaxPosition.y);

        Vector3 newPosition = new Vector3(centerX, centerY, 0.001f);
        Vector3 newScale = new Vector3(scaleX, scaleY, 1f);

        _tableGameObject.transform.position = newPosition;
        _tableGameObject.transform.localScale = newScale;
    }

    public void OnScreenDataChanged(ScreenData screenData)
    {
        _tableZonePosition = screenData.ZonePositions.FullScreen;
        UpdateTransform();
    }
}
