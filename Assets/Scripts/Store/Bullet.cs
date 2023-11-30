using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header ("Bala")]
    public int index;
    public Sprite bala;
    public float damage;
    public float range;
    public float speed;

    [Header("Municion")]
    public Sprite municionSprite;
    public int municion;
    public int currentMunicion;
    public int CurrentMunicion
    {
        get { return currentMunicion;}
        set 
        {
            value = Mathf.Clamp(value, 0, municion);
            currentMunicion = value;
        }
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            VidaEnemigo enemigo = collision.gameObject.GetComponent<VidaEnemigo>();
            enemigo.TomarDaño(damage);
            Animator animation = collision.gameObject.GetComponent<Animator>();
            animation.SetTrigger("Daño");

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Piso")
        {
            Destroy(gameObject);
        }
    }
}
