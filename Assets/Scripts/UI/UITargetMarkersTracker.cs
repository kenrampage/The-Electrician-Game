using UnityEngine;

// Manages collection and status of target markers in game UI
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

    private void UpdateMarkers()
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
