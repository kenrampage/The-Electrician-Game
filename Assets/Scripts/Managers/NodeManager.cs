using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;



public class NodeManager : Singleton<NodeManager>
{


    private UnityEvent onEdit;
    public List<Node> connectedNodes;

    public bool updatesOn = true;


    public TargetNodes[] targetNodeGroups;
    public int totalNodeGroups;
    public int nodeGroupsCompleted;

    private void Awake()
    {
        totalNodeGroups = targetNodeGroups.Length;
        foreach (var group in targetNodeGroups)
        {
            group.onComplete.AddListener(CheckNodeGroupStatus);
            group.onUncomplete.AddListener(CheckNodeGroupStatus);
        }
    }


    private void CheckNodeGroupStatus()
    {
        nodeGroupsCompleted = 0;

        foreach (var nodes in targetNodeGroups)
        {
            if (nodes.IsComplete)
            {
                nodeGroupsCompleted++;
            }
        }

        print(nodeGroupsCompleted + " out of " + totalNodeGroups + " groups completed");
    }

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
