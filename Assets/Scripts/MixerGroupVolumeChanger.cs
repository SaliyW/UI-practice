using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MixerGroupVolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float value)
    {
        _audioMixerGroup.audioMixer.SetFloat(_audioMixerGroup.name, Mathf.Log10(value) * 20);
    }
}
