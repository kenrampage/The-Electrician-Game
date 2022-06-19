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
    public UnityEvent onCompletedNodesChanged;

    public bool xrayOn;

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
        InputManager.Instance.onToggleXray.AddListener(ToggleXray);
        XrayCubesOff();
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
        int newCompletedNodes = 0;

        foreach (var node in nodes)
        {
            if (node.ConnectedToPower)
            {
                newCompletedNodes++;
            }
        }

        if (newCompletedNodes != completedNodes)
        {
            completedNodes = newCompletedNodes;
            onCompletedNodesChanged?.Invoke();
        }


    }

    [ContextMenu("Xray Off")]
    public void XrayCubesOff()
    {
        foreach (var item in nodes)
        {
            item.XrayCubeOff();
        }

        xrayOn = false;
    }

    [ContextMenu("Xray On")]
    public void XrayCubesOn()
    {

        foreach (var item in nodes)
        {
            item.XrayCubeOn();
        }

        xrayOn = true;
    }

    public void ToggleXray()
    {
        if (xrayOn)
        {
            XrayCubesOff();
        }
        else
        {
            XrayCubesOn();
        }
    }





}
