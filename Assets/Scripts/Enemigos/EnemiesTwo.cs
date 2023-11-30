using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTwo : MonoBehaviour
{
    public GameObject bala_enemy_Prefabs;
    public Transform pivod;

    private float nextBala;
    public float BalaSpawn;

    public int enemyCount;

    private float countTime;

    void Start()
    {
        countTime = 0f;

    }

    void Update()
    {
        ContadordeTiempo();
        CreateBalas();

    }
    void CreateBalas()
    {
        if (countTime > 0)
        {
            if (Time.time > nextBala)
            {
                nextBala = Time.time + BalaSpawn;
                Instantiate(bala_enemy_Prefabs, pivod.position, pivod.rotation);
                enemyCount++;
            }
        }
    }
    void ContadordeTiempo()
    {
        countTime = countTime + 1 * Time.deltaTime;
    }

}
