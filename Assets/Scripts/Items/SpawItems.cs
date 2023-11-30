using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawItems : MonoBehaviour
{
    public static SpawItems instancia;
    public GameObject[] item;

    private int spawnItem;
    private int iterator;
    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
        }
    }
    public void RandomSpawn(GameObject enemy) 
    {
        spawnItem = Random.Range(0, 100); // -> 3
        if (spawnItem < 50) // -> 1 + MAX(INTERNAL IF)
        {
            iterator = Random.Range(0, 4);
            Instantiate(item[iterator], enemy.transform.position, transform.rotation);
        } // 7
        else if (spawnItem >= 50)
        {
            return;
        } // 1
    } // -> 8
}   //Tiempo asintotico O(1) es constante 
