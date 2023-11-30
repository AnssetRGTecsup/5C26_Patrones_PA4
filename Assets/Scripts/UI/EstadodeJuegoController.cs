using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstadodeJuegoController : MonoBehaviour
{
    public GameObject[] button;
    public GameObject currentPanel;

    private bool _gameRunning = true;

    void Start()
    {
        currentPanel = button[2];
    }
    public void CambiarEstadodeJuego()
    {
        _gameRunning = !_gameRunning;

        if (_gameRunning == true)
        {
            ArrayButtons();
            Time.timeScale = 1f;
            AudioManager.instancia.audioSourceMusica.Play();
        }
        else
        {
            ArrayButtons();
            Time.timeScale = 0f;
            AudioManager.instancia.audioSourceMusica.Stop();
        }
    }
    void ArrayButtons() // 0(1) -> ASINTÓTICO
    {
        button[0].SetActive(!_gameRunning); // -> 1 + 1 + 1 = 3
        button[1].SetActive(_gameRunning); // -> 1 + 1 + 1 = 3
        currentPanel.SetActive(!_gameRunning); // -> 1 + 1 = 2
    } // 3 + 3 + 2 = 8
}
