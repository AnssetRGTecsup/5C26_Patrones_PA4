using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNoOrientedControler : MonoBehaviour
{
    public NodoControler[] AllNodescontrol;
    public NodoControler initialNodeControl;
    public EnemyControl enemyControl; 

    // Start is called before the first frame update
    void Start()
    {
        enemyControl.SetInitialNodeToMove(initialNodeControl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
