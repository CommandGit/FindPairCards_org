using UnityEngine.SceneManagement;

internal sealed class LevelLoader
{
    private Settings _settings;

    public LevelLoader(Settings settings)
    {
        _settings = settings;
    }

    public void LoadLevel(int level)
    {
        _settings.LevelSettings.LevelNumber = level;
        SceneManager.LoadScene(1);
    }
}
