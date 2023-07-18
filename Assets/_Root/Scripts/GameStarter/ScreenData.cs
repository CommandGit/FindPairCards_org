
using UnityEngine;

internal sealed class ScreenData
{
    public Vector2Int ScreenResolutions;
    public ScreenZoneSettings ZoneSettings;
    public ScreenZonePositions ZonePositions;

    public ScreenData()
    {
        ZoneSettings = new ScreenZoneSettings();
        ZonePositions = new ScreenZonePositions();
    }
}

internal sealed class ScreenZoneSettings
{
    public ZoneSettings FullScreen;
    public ZoneSettings Cards;
    public ZoneSettings Pause;
    public ZoneSettings Timer;
    public ZoneSettings Level;

    public ScreenZoneSettings()
    {
        FullScreen = new ZoneSettings();
        Cards = new ZoneSettings();
        Pause = new ZoneSettings();
        Timer = new ZoneSettings();
        Level = new ZoneSettings();
    }
}

internal sealed class ZoneSettings
{
    public Vector2 MinPosition;
    public Vector2 MaxPosition;

    public ZoneSettings()
    {
        MinPosition = Vector2.zero;
        MaxPosition = Vector2.zero;
    }

    public ZoneSettings(float minX, float minY, float maxX, float maxY)
    {
        MinPosition = new Vector2(minX, minY);
        MaxPosition = new Vector2(maxX, maxY);
    }
}

internal sealed class ScreenZonePositions
{
    public ZonePosition FullScreen;
    public ZonePosition Cards;
    public ZonePosition Pause;
    public ZonePosition Timer;
    public ZonePosition Level;

    public ScreenZonePositions()
    {
        FullScreen = new ZonePosition();
        Cards = new ZonePosition();
        Pause = new ZonePosition();
        Timer = new ZonePosition();
        Level = new ZonePosition();
    }
}

internal sealed class ZonePosition
{
    public Vector3 MinPosition;
    public Vector3 MaxPosition;

    public ZonePosition()
    {
        MinPosition = Vector3.zero;
        MaxPosition = Vector3.zero;
    }
}