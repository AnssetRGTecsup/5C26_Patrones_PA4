using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instancia;
    public AudioSource audioSourceMusica;
    public AudioSource audioSourceSFX;
    public AudioClip[] audioClips;
    public AudioMixer mixer;

    void Awake()
    {
        if(instancia != null && instancia != this)
        {
            Destroy(this);
        }

        instancia = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void SonidoGanaste()
    {
        audioSourceSFX.PlayOneShot(audioClips[0]);
    }
    public void SonidoPerdiste()
    {
        audioSourceSFX.PlayOneShot(audioClips[1]);
    }
    public void SonidoDolor()
    {
        audioSourceSFX.PlayOneShot(audioClips[2]);
    }
    public void SonidoExplosion()
    {
        audioSourceSFX.PlayOneShot(audioClips[3]);
    }
    public void SonidoRecargar()
    {
        audioSourceSFX.PlayOneShot(audioClips[4]);
    }
    public void SonidoDisparar()
    {
        audioSourceSFX.PlayOneShot(audioClips[5]);
    }
    public void SonidoVida()
    {
        audioSourceSFX.PlayOneShot(audioClips[6]);
    }
}
