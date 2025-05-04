using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerUser : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private List<Slider> _mixerSliders;

    private const string MasterVolume = nameof(MasterVolume);
    private const string ButtonsVolume = nameof(ButtonsVolume);
    private const string MusicVolume = nameof(MusicVolume);

    private readonly float _volumeMin = -80;
    private float _masterVolume;

    public void MuteMaster(bool enable)
    {
        if (enable)
        {
            _audioMixer.SetFloat(MasterVolume, _volumeMin);
        }
        else
        {
            _audioMixer.SetFloat(MasterVolume, _masterVolume);
        }

        foreach (Slider slider in _mixerSliders)
        {
            slider.interactable = !slider.interactable;
        }
    }

    public void ChangeMasterVolume(float value)
    {
        _masterVolume = Mathf.Log10(value) * 20;

        _audioMixer.SetFloat(MasterVolume, _masterVolume);
    }

    public void ChangeButtonsVolume(float value)
    {
        _audioMixer.SetFloat(ButtonsVolume, Mathf.Log10(value) * 20);
    }

    public void ChangeMusicVolume(float value)
    {
        _audioMixer.SetFloat(MusicVolume, value);
    }
}
