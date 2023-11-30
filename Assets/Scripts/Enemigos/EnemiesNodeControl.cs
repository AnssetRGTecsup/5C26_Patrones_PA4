using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesNodeControl : MonoBehaviour
{
    public float speed;
    private float step;
    private NodeControl currentNodeToMove;
    private bool onTrigger = false;
    void Start()
    {

    }
    void Update()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, currentNodeToMove.transform.position, step);
    }
    public void SelectNextNodePosition()
    {
        currentNodeToMove = currentNodeToMove.ChooseRandomAdjacentNode();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrafoSlime")
        {
            SelectNextNodePosition();
            onTrigger = !onTrigger;
            if (onTrigger)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if(collision.gameObject.tag== "pruebacolision")
        {
            Destroy(this.gameObject);
        }
    }
    public void SetInicialNodeToMove(NodeControl inicialNode)
    {
        currentNodeToMove = inicialNode;
    }
}
