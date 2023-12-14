using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanarPerderController : MonoBehaviour
{
    public EstadodeJuegoController JuegoController;
    public GameObject panel;
    public bool WIN = false;

    void Start()
    {
        WIN = false;
}
    public void Ganaste()
    {
        WIN = true;
        AudioManager.instancia.SonidoGanaste();
        JuegoController.currentPanel = panel;
        JuegoController.CambiarEstadodeJuego();
    }
    public void Perdiste()
    {
        AudioManager.instancia.SonidoPerdiste();
        JuegoController.currentPanel = panel;
        JuegoController.CambiarEstadodeJuego();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Puas")
        {
            Perdiste();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Finish")
        {
            Ganaste();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Dead")
        {
            Perdiste();
        }
    }
}
