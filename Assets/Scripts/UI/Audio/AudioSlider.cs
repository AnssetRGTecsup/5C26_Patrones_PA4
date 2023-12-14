using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private MixerManager audioMixer;
    [SerializeField] private Slider audioSlider;

    private void Start()
    {
        audioSlider.value = audioMixer.VolumeValue;
        SetVolume(audioSlider.value);
    }

    private void OnEnable()
    {
        audioSlider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        audioSlider.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(float value)
    {
        audioMixer.VolumeValue = value;
    }
}
