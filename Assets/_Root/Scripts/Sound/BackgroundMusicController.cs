using Extension;
using Newtonsoft.Json.Bson;
using System.Collections.ObjectModel;
using UnityEngine;

internal sealed class BackgroundMusicController : BaseEnabled, IUpdate
{
    private const string PREFAB_PATH = "Prefabs/Sound/BackgroundMusic";
    private const string MENU_BACKGROUND_MUSIC_COLLECTION_PATH = "Sound/BackGroungMusic/MainManuBackgroundMusicPathes";
    private const string GAME_BACKGROUND_MUSIC_COLLECTION_PATH = "Sound/BackGroungMusic/GameBackgroundMusicPathes";

    private StringCollection _clipPathCollection;

    private BackgroundMusicView _view;

    public BackgroundMusicController()
    {
        _view = GameObject.FindObjectOfType<BackgroundMusicView>();
        if (_view == null)
        {
            GameObject prefab = Resources.Load<GameObject>(PREFAB_PATH);
            GameObject go = GameObject.Instantiate(prefab);
            _view = go.GetComponent<BackgroundMusicView>();
        }
    }

    public void Update(float deltaTime)
    {
        if (!_enable) return;

        if (!_view.AudioSource.isPlaying)
        {
            PlayFromCurrentCollection();
        }
    }

    private void PlayFromCurrentCollection()
    {
        string randomPath = _clipPathCollection.Collection.GetRandom();
        AudioClip clip = Resources.Load<AudioClip>(randomPath);
        _view.AudioSource.clip = clip;
        _view.AudioSource.Play();
    }

    public void PlayMenuBackgroundRandom()
    {
        _enable = true;

        _clipPathCollection = Resources.Load<StringCollection>(MENU_BACKGROUND_MUSIC_COLLECTION_PATH);
        PlayFromCurrentCollection();
    }

    public void PlayGameBackgroundRandom()
    {
        _enable = true;

        _clipPathCollection = Resources.Load<StringCollection>(GAME_BACKGROUND_MUSIC_COLLECTION_PATH);
        PlayFromCurrentCollection();
    }
}
