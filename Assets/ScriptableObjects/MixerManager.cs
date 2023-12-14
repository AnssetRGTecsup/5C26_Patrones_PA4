using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "MixerManager", menuName = "ScriptableObjects/Audio/MixerManager", order = 0)]
public class MixerManager : ScriptableObject
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float volumeValue;
    [SerializeField] private string audioKey;

    public float VolumeValue
    {
        get { return volumeValue; }
        set
        {
            volumeValue = value;
            audioMixer.SetFloat(audioKey, ToDecibels(volumeValue));
        }
    }

    private void OnEnable()
    {
        audioMixer.SetFloat(audioKey, ToDecibels(volumeValue));
    }

    private float ToDecibels(float value)
    {
        return Mathf.Log(value) * 20f;
    }
}
