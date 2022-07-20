using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Node : MonoBehaviour
{
    [Header("Passthrough References")]
    [HideInInspector] public NodeVisuals NodeVisuals;

    [Header("Settings")]
    [SerializeField] private bool _isPowerSource;

    [Header("Status")]
    [SerializeField] private bool _isConnectedToPower;
    [SerializeField] private List<Node> _connectedNodes;

    [Header("Events")]
    [HideInInspector] public UnityEvent OnPowerStatusChanged;

    private void Awake()
    {
        NodeVisuals = GetComponent<NodeVisuals>();
        if (_isPowerSource)
        {
            ConnectPower();
        }
    }

    private void Update()
    {
        CheckPowerStatusOfConnectedNodes();
    }

    #region Power Functions
    public void ConnectPower()
    {
        if (!_isConnectedToPower)
        {
            _isConnectedToPower = true;
            OnPowerStatusChanged?.Invoke();
        }

        if (!_isPowerSource)
        {
            NodeVisuals.PowerOn();
        }
    }

    public void DisconnectPower()
    {
        if (!_isPowerSource)
        {
            if (_isConnectedToPower)
            {
                _isConnectedToPower = false;
                OnPowerStatusChanged?.Invoke();
            }

            NodeVisuals.PowerOff();
        }
    }

    public bool CheckPowerStatus()
    {
        return _isConnectedToPower;
    }
    #endregion

    #region Node Functions
    public void AddConnectedNode(Node node)
    {
        if (!_connectedNodes.Contains(node))
        {
            _connectedNodes.Add(node);
        }

    }

    public void RemoveConnectedNode(Node node)
    {
        _connectedNodes.Remove(node);
    }

    public bool CheckIfConnectedToNode(Node node)
    {
        if (_connectedNodes.Contains(node))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckPowerStatusOfConnectedNodes()
    {
        if (!_isPowerSource)
        {
            if (_connectedNodes.Count == 0)
            {
                DisconnectPower();
            }
            else
            {
                foreach (var node in _connectedNodes)
                {
                    if (node.CheckPowerStatus())
                    {
                        ConnectPower();
                        break;
                    }
                    else
                    {
                        DisconnectPower();
                    }
                }
            }
        }
    }

    #endregion
}
