using UnityEngine;

internal sealed class SoundController
{
    private GameObject _soundFX3DPrefab;
    private GameObject _soundFX2DPrefab;
    public SoundController()
    {
        _soundFX3DPrefab = Resources.Load<GameObject>("Prefabs/Sound/SoundFX3D");
        _soundFX2DPrefab = Resources.Load<GameObject>("Prefabs/Sound/SoundFX2D");
    }

    private void PlayClip(GameObject go, string audioSourcePath, float volume)
    {
        SoundFX3DView soundFX3DView = go.GetComponent<SoundFX3DView>();
        AudioSource audioSource = soundFX3DView.AudioSource;

        AudioClip audioClip = Resources.Load<AudioClip>(audioSourcePath);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        GameObject.Destroy(go, audioClip.length + 1);
    }

    public GameObject PlayOnParent(string audioSourcePath, float volume, Transform parent)
    {
        GameObject go = GameObject.Instantiate(_soundFX3DPrefab, parent);
        PlayClip(go, audioSourcePath, volume);
        return go;
    }

    public GameObject Play2D(string audioSourcePath, float volume)
    {
        GameObject go = GameObject.Instantiate(_soundFX2DPrefab);
        PlayClip(go, audioSourcePath, volume);
        return go;
    }
}
