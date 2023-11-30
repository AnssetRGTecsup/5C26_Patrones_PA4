using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoControler : MonoBehaviour
{
    public NodoControler[] AllAdjacentNodes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public NodoControler ChooseRandomAdjacentNode()
    {
        int randomPosition = Random.Range(0, AllAdjacentNodes.Length);
        return AllAdjacentNodes[randomPosition];
    }

}
