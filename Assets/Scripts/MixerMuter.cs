using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MixerMuter : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _volumeParameterName;
    [SerializeField] private List<Slider> _mixerSliders;

    private const string MasterVolume = nameof(MasterVolume);
    private const string ButtonsVolume = nameof(ButtonsVolume);
    private const string MusicVolume = nameof(MusicVolume);

    private readonly float _volumeMin = -80;
    private float _currentVolume;

    public void Mute(bool enable)
    {
        if (enable)
        {
            _audioMixer.GetFloat(_volumeParameterName, out _currentVolume);
            _audioMixer.SetFloat(_volumeParameterName, _volumeMin);
        }
        else
        {
            _audioMixer.SetFloat(_volumeParameterName, _currentVolume);
        }

        foreach (Slider slider in _mixerSliders)
        {
            slider.interactable = !slider.interactable;
        }
    }
}
