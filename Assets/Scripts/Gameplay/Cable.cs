using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public CableTransform cableTransform;

    public Node sourceNode;
    public Node endNode;

    private void OnEnable()
    {
        cableTransform = GetComponent<CableTransform>();
    }


    public void AddEndNodeToSourceNode()
    {
        if (endNode != null)
        {
            sourceNode.AddConnectedNode(endNode);
        }

    }


    public void AddSourceNodeToEndNode()
    {
        if (endNode != null)
        {
            endNode.AddConnectedNode(sourceNode);
        }

    }

    public void AddSourceNodeToManager()
    {
        NodeManager.Instance.AddConnectedNode(sourceNode);
    }

    public void AddEndNodeToManager()
    {
        if (endNode != null)
        {
            NodeManager.Instance.AddConnectedNode(endNode);
        }
    }


    public void RemoveEndNodeFromSourceNode()
    {
        if (endNode != null)
        {
            sourceNode.RemoveConnectedNode(endNode);
        }
    }

    public void RemoveSourceNodeFromEndNode()
    {
        if (endNode != null)
        {
            endNode.RemoveConnectedNode(sourceNode);
        }
    }

    public void RemoveSourceNodeFromManager()
    {
        NodeManager.Instance.RemoveConnectedNode(sourceNode);
    }

    public void RemoveEndNodeFromManager()
    {
        if (endNode != null)
        {
            NodeManager.Instance.RemoveConnectedNode(endNode);
        }
    }

    public void SetSourceNode(Node node)
    {
        sourceNode = node;
    }
    public void SetEndNode(Node node)
    {
        endNode = node;
    }

    public void ClearSourceNode()
    {
        sourceNode = null;
    }

    public void ClearEndNode()
    {
        endNode = null;
    }

    public Node GetSourceNode()
    {
        return sourceNode.GetComponent<Node>();
    }

    public Node GetendNode()
    {
        return endNode.GetComponent<Node>();
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
