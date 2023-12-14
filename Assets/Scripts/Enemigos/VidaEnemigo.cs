using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public GameObject boomPrefab;
    public float vida;
    public float puntos;

    public bonnyPool objectPooling;

    public void TomarDaño(float daño)
    {
        vida -= daño; // 2; 1 comparacion y 1 resta
        if (vida <= 0) // 1 + MAX( If, Else)
        {
            EnemyDead(); //10
        }
    } //2+11=13
    //Tiempo asintotico O(1) es constante 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<VidaPlayer>().TomarDaño();
            vida -= 1;
            //DestroyEnemy();

            ValidatePool();
        }

        if (collision.gameObject.tag == "LimiteEnemy" || 
            collision.gameObject.tag == "Puas")
        {
            //DestroyEnemy();

            ValidatePool();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dead")
        {
            //DestroyEnemy();

            ValidatePool();
        }
    }
    void EnemyDead()
    {
        PuntosControl.instancia.puntos += puntos; // 2; 1 comparacion y 1 suma 
        SpawItems.instancia.RandomSpawn(gameObject); //8 asignacion 
        AudioManager.instancia.SonidoExplosion(); // 1
        GameObject explotion = Instantiate(boomPrefab, transform.position, transform.rotation); //4 asignacion 
        Destroy(explotion, 1f); // 2 asignacion
                                //DestroyEnemy();

        ValidatePool();
    } // 2+8+4+1+2+1 = 18
    //Tiempo asintotico O(1) es constante 

    void DestroyEnemy() // -> 0(1) -> ASINTÓTICO
    {
        GameObject explotion = Instantiate(boomPrefab, transform.position, transform.rotation); // -> 1 + 3 
        Destroy(explotion, 1f); // -> 2
                                //DestroyEnemy();

        ValidatePool();
    } //// -> 1 + 3 + 2 + 1 = 7

    private void ValidatePool()
    {
        if (objectPooling == null) return;

        objectPooling.devolverEnemy(this.gameObject);
    }
}
