using UnityEngine;
using UnityEngine.Audio;

internal sealed class AudioMixerController
{
    private const string AUDIO_MIXER_PATH = "Sound/Mixer/Mixer";
    private const string MASTER_VOLUME_PARAM_NAME = "MasterVolume";

    private AudioMixer _audioMixer;
    private SoundSettings _soundSettings;

    public AudioMixerController()
    {
        _audioMixer = Resources.Load<AudioMixer>(AUDIO_MIXER_PATH);
    }

    private void SetMasterValume(float newVolume)
    {
        _audioMixer.SetFloat(MASTER_VOLUME_PARAM_NAME, newVolume);
    }

    private void UpdateAudioMixerData()
    {
        SetMasterValume(_soundSettings.MasterVolume);
    }

    public void OnChangeSettings(SoundSettings soundSettings)
    {
        _soundSettings = soundSettings;
        UpdateAudioMixerData();
    }
}
