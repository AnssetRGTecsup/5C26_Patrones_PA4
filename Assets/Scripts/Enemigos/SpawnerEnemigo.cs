using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigo : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float currentTime;
    public float nextEnemy;

    void Start()
    {
        
    }

    void Update()
    {
        CreateEnemy();
    }
    void CreateEnemy() // -> 0(1) -> ASINTÓTICO
    {
        currentTime += Time.deltaTime; // 2

        if (currentTime > nextEnemy) // -> 1 + MAX (INTERNAL IF)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation); // -> 3 
            currentTime = 0; // -> 1
        }
    } // -> 2 + 1 + (3 + 1) = 7
}
