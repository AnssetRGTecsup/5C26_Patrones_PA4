using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuardarRecord : MonoBehaviour
{
    public TextMeshProUGUI[] score;
    public TimerController timer;
    private float puntos;

    private float pointRecord;
    private string tiempoRecord;

    void Start()
    {
        pointRecord = PlayerPrefs.GetFloat("RecordPuntos", 0f);
        tiempoRecord = PlayerPrefs.GetString("RecordTiempo", "--:--");
    }
    void Update()
    {
        UltimoPuntaje();
        PuntajeRecord();
    }
    void UltimoPuntaje()
    {
        puntos = PuntosControl.instancia.puntos;
        score[0].text = "PUNTOS: "+ puntos.ToString() + "pts.\nTIEMPO: " + timer.timeText.text;
        score[1].text = "¡RECORD!\nPUNTOS: " + pointRecord.ToString() + "pts.\nTIEMPO: " + tiempoRecord;
    }
    void PuntajeRecord() // -> O(1) -> ASINTÓTICO
    {
        if (puntos > pointRecord) // -> 1 + MAX (INTERNAL IF)
        {
            PlayerPrefs.SetFloat("RecordPuntos", puntos); // -> 1
            PlayerPrefs.SetString("RecordTiempo", timer.timeText.text); //-> 1

            pointRecord = PlayerPrefs.GetFloat("RecordPuntos", 0); // -> 1
            tiempoRecord = PlayerPrefs.GetString("RecordTiempo", "--:--"); // -> 1
            //Debug.Log(pointRecord + " " + tiempoRecord);

        } // -> 1 + 1 + 1 + 1 + 1 = 5
    } 
}
