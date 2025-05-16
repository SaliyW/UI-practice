using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MixerGroupMuter : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private List<Slider> _mixerSliders;

    private Toggle _toggle;
    private readonly float _volumeMin = -80;
    private float _currentVolume;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(Mute);
    }

    private void Mute(bool enable)
    {
        if (enable)
        {
            _audioMixerGroup.audioMixer.GetFloat(_audioMixerGroup.name, out _currentVolume);
            _audioMixerGroup.audioMixer.SetFloat(_audioMixerGroup.name, _volumeMin);
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat(_audioMixerGroup.name, _currentVolume);
        }

        foreach (Slider slider in _mixerSliders)
        {
            slider.interactable = !slider.interactable;
        }
    }
}
