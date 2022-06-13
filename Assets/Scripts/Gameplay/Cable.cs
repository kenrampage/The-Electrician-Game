using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public CableTransform cableTransform;

    public Node sourceNode;
    public Node endNode;
    //track power status
    // public bool connectedToPower;

    private string cableTag = "Cable";
    private string nodeTag = "Node";

    private void OnEnable()
    {
        cableTransform = GetComponent<CableTransform>();
    }

    public void SetSourceNode(Node node)
    {
        sourceNode = node;
    }

    public void SetEndNode(Node node)
    {
        endNode = node;
    }

    public Node GetSourceNode()
    {
        return sourceNode;
    }

    public Node GetendNode()
    {
        return endNode;
    }

    public void ClearSourceNode()
    {
        sourceNode.RemoveConnectedNode(endNode);
    }

    public void ClearEndNode()
    {
        endNode.RemoveConnectedNode(sourceNode);
    }

    // public bool CheckConnectedToPower()
    // {
    //     if (sourceNode.connectedToPower || endNode.connectedToPower)
    //     {
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }

}
