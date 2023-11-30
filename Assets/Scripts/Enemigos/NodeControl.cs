using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public NodeControl[] allAdjacentNodes;
    //public int grafoCost;
    void Start(){}
    void Update(){}
    public NodeControl ChooseRandomAdjacentNode()
    {
        //int randomPosition = Random.Range(0, allAdjacentNodes.Length);
        return allAdjacentNodes[0];
    }
}
