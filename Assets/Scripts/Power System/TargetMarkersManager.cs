using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMarkersManager : MonoBehaviour
{

    public TargetMarkers[] targetMarkers;
    private TargetNodes targetNodes;
    private int completedNodes;

    private void Awake()
    {
        targetNodes = FindObjectOfType<TargetNodes>();
        targetNodes.onCompletedNodesChanged.AddListener(HandleCompletedNodesChanged);
    }

    public void HandleCompletedNodesChanged()
    {
        int newCompletedNodes = targetNodes.completedNodes;

        if (newCompletedNodes != completedNodes)
        {
            completedNodes = newCompletedNodes;
            UpdateMarkers();
        }

    }

    public void UpdateMarkers()
    {
        foreach (var item in targetMarkers)
        {
            item.TurnOff();
        }

        for (int i = 0; i < targetNodes.completedNodes; i++)
        {
            targetMarkers[i].TurnOn();
        }
    }


}
