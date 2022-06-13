using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public CableTransform cableTransform;

    // //track currently connected cables and Nodes
    // public List<Cable> connectedCableList;
    // public List<Node> connectedNodeList;

    //track power status
    public bool connectedToPower;

    private string cableTag = "Cable";
    private string nodeTag = "Node";

    private void OnEnable()
    {
        cableTransform = GetComponent<CableTransform>();
    }

}
