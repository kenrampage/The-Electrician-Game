using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class NodeManager : Singleton<NodeManager>
{
    //track all target nodes and their power status
    //once all target nodes are powered on you win

    public bool powerOn;

    private UnityEvent onEdit;
    public UnityEvent onPowerOn;

    // public HashSet<Node> connectedNodes;
    public List<Node> connectedNodes;

    public bool updatesOn = true;

    private void Update()
    {
        // if (updatesOn)
        // {
        //     foreach (var node in connectedNodes)
        //     {
        //         node.CheckStatusOfConnectedNodes();
        //     }
        // }

    }

    public void ResetConnectedNodes()
    {
        foreach (var node in connectedNodes)
        {
            print("Nodes Reset!");
            node.DisconnectPower();
        }
    }

    public void TurnUpdatesOn()
    {
        foreach (var node in connectedNodes)
        {
            print("Updates On");
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
        // print("OnEdit Invoked");
        onEdit?.Invoke();
    }

    public void PowerOff()
    {
        foreach (var node in connectedNodes)
        {
            node.PowerOff();
            powerOn = false;
        }
    }

    public void PowerOn()
    {
        foreach (var node in connectedNodes)
        {
            node.PowerOn();
            powerOn = true;
        }
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

    //every time a cable is connected to a node add it to the connected node hashlist
    //remove that node from hashlist if cable is removed, and there are no other cables connected
    //in update foreach through hashlist to check connection status for each nodes connected nodes




}
