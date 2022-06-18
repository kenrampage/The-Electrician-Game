using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetNodes : MonoBehaviour
{
    public string groupName;
    public Node[] nodes;
    public int totalNodes;
    public int completedNodes;

    public UnityEvent onComplete;
    public UnityEvent onUncomplete;

    private bool isComplete;
    public bool IsComplete
    {
        get { return isComplete; }
        set
        {
            if (value == true && value != isComplete)
            {
                isComplete = value;
                print(groupName + " is complete!");
                onComplete?.Invoke();
            }
            else if (value == false && value != isComplete)
            {
                isComplete = value;
                onUncomplete?.Invoke();
            }

        }
    }

    private void Awake()
    {
        foreach (var node in nodes)
        {
            node.onPowerStatusChanged.AddListener(CheckNodeStatus);
        }
    }

    private void SetTotalNodes()
    {
        totalNodes = nodes.Length;
    }

    private void CheckNodeStatus()
    {
        foreach (var node in nodes)
        {
            if (!node.ConnectedToPower)
            {
                IsComplete = false;
                return;
            }
            else
            {
                IsComplete = true;
            }
        }
    }


}
