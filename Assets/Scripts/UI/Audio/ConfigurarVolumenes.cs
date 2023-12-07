using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ConfigurarVolumenes : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider sliderMusica;
    public Slider sliderSFX;
    public string MIXER_MUSICA = "VolumenMusica";
    public string MIXER_SFX = "VolumenSFX";

    void Awake()
    {
        sliderMusica.onValueChanged.AddListener(CambiarVolumenMusica);
        sliderSFX.onValueChanged.AddListener(CambiarVolumenSFX);
    }
    void Start()
    {
        sliderMusica.value = PlayerPrefs.GetFloat("volumenMusica", 1f);
        sliderSFX.value = PlayerPrefs.GetFloat("volumenSFX", 1f);
    }
    public void CambiarVolumenMusica(float valor)
    {
        audioMixer.SetFloat(MIXER_MUSICA, Mathf.Log10(valor) * 30);
    }
    public void CambiarVolumenSFX(float valor)
    {
        audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(valor) * 30);
    }
    public void OnDisable()
    {
        PlayerPrefs.SetFloat("volumenMusica", sliderMusica.value);
        PlayerPrefs.SetFloat("volumenSFX", sliderSFX.value);
    }
}
