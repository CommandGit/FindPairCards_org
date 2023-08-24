using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class LevelLoader : MonoBehaviour
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
