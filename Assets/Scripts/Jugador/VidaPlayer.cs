using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    //public GameObject boomPrefab;

    public PlayerSO vidaPlayer;
  

    public Image[] vidas;

    public Sprite corazon;
    public Sprite dead;

    public bool deadPlaver = false;

    public GanarPerderController ganarPerder;

    private Animator animator;

    void Start()
    {
        vidaPlayer.vida = 3;
        deadPlaver = false;
        VidaControl();

        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (deadPlaver == false)
        {
            VidaControl();
        }
    }
    void VidaControl()
    {
        if (vidaPlayer.vida == 3)
        {
            for (int i = 0; i < vidas.Length; i++)
            {
                vidas[i].sprite = corazon;
            }
        }
        if (vidaPlayer.vida == 2)
        {
            vidas[0].sprite = dead;

            for (int i = 1; i < vidas.Length; i++)
            {
                vidas[i].sprite = corazon;
            }
        }
        if (vidaPlayer.vida == 1)
        {
            for (int i = 0; i < vidas.Length - 1; i++)
            {
                vidas[i].sprite = dead;
            }

            vidas[2].sprite = corazon;
        }
        if (vidaPlayer.vida == 0)
        {
            for (int i = 0; i < vidas.Length; i++)
            {
                vidas[i].sprite = dead;
            }

            deadPlaver = true;
        }

        if (deadPlaver)
        {
            ganarPerder.Perdiste();
        }
    }
    public void TomarDaño()
    {
        vidaPlayer.vida -= 1;
        AudioManager.instancia.SonidoDolor();
        animator.SetTrigger("Daño");
    }
}
