using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Controlador : MonoBehaviour
{
    [Header("Queue")]
    public Queue<NodeQueue> historial = new Queue<NodeQueue>();
    public static Queue<NodeQueue> historial02;

    [SerializeField] private float puntaje;
    [SerializeField] private float tiempo;

    public NodeQueue nodeQueue;
    public NodeQueue tmp;
    public TextMeshProUGUI[] textPuntaje;
    public TextMeshProUGUI[] textTiempo;

    public int tamañoHistorial;

    [Header("Historial")]
    public PuntosControl puntajeWIN;
    public TimerController tiempoWIN;

    public GanarPerderController ganarPerder;
    void Awake()
    {

    }
    void Start()
    {
        if(historial02 != null)
        {
            historial = historial02;
        }
    }
    void Update()
    {
        if (ganarPerder.WIN)
        {
            nodeQueue.puntaje = puntajeWIN.puntos;
            nodeQueue.tiempo = tiempoWIN.timeRemaining;
            historial.Enqueue(nodeQueue);
            ganarPerder.WIN = false;
        }
    }
    public void AgregarScore()
    {
        Debug.Log(historial.length);
        historial02 = historial;
        MostrarDatos();
    }
    public void MostrarDatos()
    {
        if (historial.length > tamañoHistorial)
        {
            historial.Dequeue();
        }
        if (historial.length > 0)
        {
            for (int i = 0; i < historial.length; i++)
            {
                textPuntaje[historial.length - (i + 1)].text = historial.GetNodeValueAtPosition(i).puntaje.ToString();
                tiempoWIN.DisplayTime(historial.GetNodeValueAtPosition(i).tiempo, textTiempo[historial.length - (i + 1)]);
            }
        }
    }
}