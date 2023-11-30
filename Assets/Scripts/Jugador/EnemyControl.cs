using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed;
    private float step;
    public float energy = 100; 
    public NodoControler currentNodeToMove;
    public bool onTrigger = false;
    void Start()
    {
        
    }

    void Update()
    {
        step = speed = Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, currentNodeToMove.transform.position, step);
    }

    public void SelectNextNodePosition()
    {
        currentNodeToMove = currentNodeToMove.ChooseRandomAdjacentNode();

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        SelectNextNodePosition();

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.tag == "Node")
        {
            energy = energy - 20;
            Debug.Log("Energy = " + energy);

            if (energy > 0)
            {
                SelectNextNodePosition();
            }
            else
            {
                StartCoroutine("Wait");
                energy = 100;
            }
        }
    }

    public void SetInitialNodeToMove (NodoControler initialNode)
    {
        currentNodeToMove = initialNode; 
    }
}
