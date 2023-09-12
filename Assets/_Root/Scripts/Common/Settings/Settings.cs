
internal sealed class Settings
{
    public GameSettings GameSettings = new GameSettings();
    public LevelSettings LevelSettings = new LevelSettings();
}

internal sealed class GameSettings
{
    public PlaySettings PlaySettings = new PlaySettings();
    public SoundSettings SoundSettings = new SoundSettings();
    public DesignSettings DesignSettings = new DesignSettings();
}

internal sealed class LevelSettings
{
    public int LevelNumber;
    public bool PreviewCards;

    public LevelSettings()
    {
        SetDefaultValues();
    }

    private void SetDefaultValues()
    {
        LevelNumber = 7; //testing default value
        PreviewCards = true; //testing default value
    }
}

internal sealed class PlaySettings
{
}

internal sealed class SoundSettings
{
}

internal sealed class DesignSettings
{
}