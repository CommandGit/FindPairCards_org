using UnityEngine;

internal sealed class SoundController
{
    private GameObject _soundFX3DPrefab;
    public SoundController()
    {
        _soundFX3DPrefab = Resources.Load<GameObject>("Prefabs/Sound/SoundFX3D");
    }

    public GameObject PlayOnParent(string audioSourcePath, float volume, Transform parent)
    {
        GameObject go = GameObject.Instantiate(_soundFX3DPrefab, parent);
        SoundFX3DView soundFX3DView = go.GetComponent<SoundFX3DView>();
        AudioSource audioSource = soundFX3DView.AudioSource;

        AudioClip audioClip = Resources.Load<AudioClip>(audioSourcePath);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        GameObject.Destroy(go, audioClip.length + 1);

        return go;
    }
}
