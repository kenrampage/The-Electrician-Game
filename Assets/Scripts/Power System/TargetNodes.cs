using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetNodes : MonoBehaviour
{
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

        SetTotalNodes();
    }

    private void SetTotalNodes()
    {
        totalNodes = nodes.Length;
    }

    private void CheckNodeStatus()
    {
        completedNodes = 0;

        foreach (var node in nodes)
        {
            if (node.ConnectedToPower)
            {
                completedNodes++;
            }
        }

        print(completedNodes + " nodes completed out of " + totalNodes + " total");
    }




}
