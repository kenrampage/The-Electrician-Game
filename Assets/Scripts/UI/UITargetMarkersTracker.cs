using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UITargetMarkersTracker : MonoBehaviour
{
    [Header("UI Target Objects")]
    [SerializeField] private UITargetMarker[] _targetMarkers;

    private NodeManager _nodeManager;
    private int _completedNodes;

    private void Awake()
    {   
        _nodeManager = NodeManager.Instance;
        _nodeManager.OnTargetNodesCompleteChanged.AddListener(HandleCompletedNodesChanged);
    }

    public void HandleCompletedNodesChanged()
    {
        int newCompletedNodes = _nodeManager.GetCompletedTargetNodes();

        if (newCompletedNodes != _completedNodes)
        {
            _completedNodes = newCompletedNodes;
            UpdateMarkers();
        }

    }

    public void UpdateMarkers()
    {
        foreach (var item in _targetMarkers)
        {
            item.TurnOff();
        }

        for (int i = 0; i < _nodeManager.GetCompletedTargetNodes(); i++)
        {
            _targetMarkers[i].TurnOn();
        }
    }


}
