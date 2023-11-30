using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPatas : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    private float step;

    void Awake()
    {

    }


    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distancia;
        distancia = Vector2.Distance(player.transform.position, transform.position);
        step = moveSpeed * Time.deltaTime;

        if (distancia < 15)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, step);

            if (transform.position.x < player.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            transform.position = new Vector2(transform.position.x - step, transform.position.y);
        }

        Debug.DrawLine(player.transform.position, transform.position, Color.red, Time.deltaTime, false);
    }
}
