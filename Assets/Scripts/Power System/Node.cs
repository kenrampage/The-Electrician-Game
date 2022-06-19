using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Node : MonoBehaviour
{
    private SphereCollider col;

    public GameObject powerConnectedIndicator;
    public GameObject powerDisconnectedIndicator;

    public MeshRenderer[] highlightMeshes;
    // public Vector3 rotateSpeed;

    //track power status
    public bool powerSource;
    public bool connectedToPower;
    public bool ConnectedToPower
    {
        get { return connectedToPower; }
        set
        {
            if (connectedToPower != value)
            {
                connectedToPower = value;
                onPowerStatusChanged?.Invoke();
            }
            else
            {
                connectedToPower = value;
            }

        }

    }


    // public bool poweredOn;

    public bool updatesOn;

    //track installed box
    public List<Node> connectedNodes;

    public UnityEvent onPowerStatusChanged;


    private void Awake()
    {
        TurnUpdatesOn();
        if (powerSource)
        {
            ConnectPower();
            NodeManager.Instance.AddConnectedNode(this);
        }
        col = GetComponent<SphereCollider>();


        // NodeManager.Instance.onEdit.AddListener(HandleEdit);
        // NodeManager.Instance.onZone1PowerOn.AddListener(PowerOn);
        // NodeManager.Instance.onZone1PowerOff.AddListener(PowerOff);

    }

    public void TurnUpdatesOn()
    {
        updatesOn = true;
    }

    public void TurnUpdatesOff()
    {
        updatesOn = false;
    }

    private void Update()
    {
        CheckStatusOfConnectedNodes();

    }

    public void HandleEdit()
    {

    }

    public void HighlightOn()
    {
        foreach (var mesh in highlightMeshes)
        {
            mesh.material.EnableKeyword("_EMISSION");
        }
    }

    public void HighlightOff()
    {
        foreach (var mesh in highlightMeshes)
        {
            mesh.material.DisableKeyword("_EMISSION");
        }
    }

    public void CheckStatusOfConnectedNodes()
    {
        if (!powerSource)
        {
            if (connectedNodes.Count == 0)
            {
                DisconnectPower();
            }
            else
            {
                foreach (var node in connectedNodes)
                {
                    if (node.ConnectedToPower)
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

    [ContextMenu("Connect Power")]
    public void ConnectPower()
    {

        if (!powerSource)
        {
            ConnectedToPower = true;
            powerConnectedIndicator.SetActive(true);
            powerDisconnectedIndicator.SetActive(false);
        }

    }


    public void DisconnectPower()
    {
        if (!powerSource)
        {
            ConnectedToPower = false;
            powerConnectedIndicator.SetActive(false);
            powerDisconnectedIndicator.SetActive(true);

        }
    }

    public void AddConnectedNode(Node node)
    {
        if (!connectedNodes.Contains(node))
        {
            connectedNodes.Add(node);
        }

    }

    public void RemoveConnectedNode(Node node)
    {
        connectedNodes.Remove(node);
    }

}
