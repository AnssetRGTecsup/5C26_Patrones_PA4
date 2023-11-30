using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphOrientedControl : MonoBehaviour
{
    public NodeControl[] allNodesControl;
    public NodeControl inicialNodeControl;
    public EnemiesNodeControl enemigoControl;

    void Start()
    {
        enemigoControl.SetInicialNodeToMove(inicialNodeControl);
    }

    void Update()
    {

    }
}
