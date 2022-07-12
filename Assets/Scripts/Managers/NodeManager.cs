using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;



public class NodeManager : Singleton<NodeManager>
{
    private UnityEvent onEdit;
    public List<Node> connectedNodes;

    public bool updatesOn = true;


    public void ResetConnectedNodes()
    {
        foreach (var node in connectedNodes)
        {
            // print("Nodes Reset!");
            node.DisconnectPower();
        }
    }

    public void TurnUpdatesOn()
    {
        foreach (var node in connectedNodes)
        {
            // print("Updates On");
            node.TurnUpdatesOn();
        }
    }

    public void TurnUpdatesOff()
    {

        foreach (var node in connectedNodes)
        {
            print("Updates Off");
            node.TurnUpdatesOff();
        }
        ResetConnectedNodes();
    }

    public void OnEdit()
    {
        onEdit?.Invoke();
    }


    public void AddConnectedNode(Node node)
    {
        connectedNodes.Add(node);
    }

    public void RemoveConnectedNode(Node node)
    {
        node.CheckStatusOfConnectedNodes();
        connectedNodes.Remove(node);
    }


}
