using UnityEngine.Events;
using UnityEngine;

// Tracks node statuses and invokes events based on status changes
public class NodeManager : Singleton<NodeManager>
{
    [Header("References")]
    [SerializeField] private Node[] _targetNodes;

    [Header("Events")]
    [HideInInspector]
    public UnityEvent OnTargetNodesCompleteChanged;
    public UnityEvent OnAllTargetNodesCompleted;

    private int _totalTargetNodes;
    private int _completedTargetNodes;


    private void Awake()
    {
        foreach (var node in _targetNodes)
        {
            node.OnPowerStatusChanged.AddListener(CheckTargetNodesStatus);
        }

        CalcTotalNodes();
    }

    private void CalcTotalNodes()
    {
        _totalTargetNodes = _targetNodes.Length;
    }

    // Checks power status of all target nodes
    private void CheckTargetNodesStatus()
    {
        int newCompletedNodes = 0;

        foreach (var node in _targetNodes)
        {
            if (node.CheckPowerStatus())
            {
                newCompletedNodes++;
            }
        }

        if (newCompletedNodes != _completedTargetNodes)
        {
            _completedTargetNodes = newCompletedNodes;
            OnTargetNodesCompleteChanged?.Invoke();
        }

        if (_completedTargetNodes == _totalTargetNodes)
        {
            AllTargetNodesCompleted();
        }
    }

    private void AllTargetNodesCompleted()
    {
        OnAllTargetNodesCompleted?.Invoke();
    }

    public int GetCompletedTargetNodes()
    {
        return _completedTargetNodes;
    }
}
