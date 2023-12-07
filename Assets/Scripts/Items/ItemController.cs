using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    void DestruirMunicion()
    {
        AudioManager.instancia.SonidoRecargar();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AdministradorBalas balas = AdministradorBalas.instancia;
            Bullet tmp;

            if (this.gameObject.tag == "MunicionBase")
            {
                tmp = balas.doubleLinkedList.GetNodeValueAtPosition(0);
                tmp.currentMunicion = tmp.municion;
                DestruirMunicion();
            }
            if (this.gameObject.tag == "Municion1")
            {
                tmp = balas.doubleLinkedList.GetNodeValueAtPosition(1);
                tmp.currentMunicion = tmp.municion;
                DestruirMunicion();
            }
            if (this.gameObject.tag == "Municion2")
            {
                tmp = balas.doubleLinkedList.GetNodeValueAtPosition(2);
                tmp.currentMunicion = tmp.municion;
                DestruirMunicion();
            }
            if (this.gameObject.tag == "Municion3")
            {
                tmp = balas.doubleLinkedList.GetNodeValueAtPosition(3);
                tmp.currentMunicion = tmp.municion;
                DestruirMunicion();
            }
            if (this.gameObject.tag == "Vida")
            {
                collision.gameObject.GetComponent<VidaPlayer>().vidaPlayer.vida += 1;
                AudioManager.instancia.SonidoVida();
                Destroy(gameObject);
            }
        }
    }
}
