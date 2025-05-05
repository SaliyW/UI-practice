using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MixerVolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _volumeParameterName;

    public void ChangeVolume(float value)
    {
        _audioMixer.SetFloat(_volumeParameterName, Mathf.Log10(value) * 20);
    }
}
