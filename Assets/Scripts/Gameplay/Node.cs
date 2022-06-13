using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private SphereCollider col;

    public GameObject powerConnectedIndicator;
    public GameObject powerDisconnectedIndicator;
    public Vector3 rotateSpeed;

    //track power status
    public bool connectedToPower;
    public bool poweredOn;
    public bool powerSource;

    //track installed box
    public WiringBox installedBox;

    private LayerMask cableLayerMask;

    public List<Node> connectedNodes;

    private void Awake()
    {
        if (powerSource)
        {
            ConnectPower();
        }
        col = GetComponent<SphereCollider>();
        NodeManager.Instance.onEdit.AddListener(HandleEdit);
        NodeManager.Instance.onZone1PowerOn.AddListener(PowerOn);
        NodeManager.Instance.onZone1PowerOff.AddListener(PowerOff);
    }

    private void FixedUpdate()
    {
        if (poweredOn)
        {
            powerConnectedIndicator.transform.Rotate(rotateSpeed, Space.Self);
        }
    }

    //trigger whenever a change is made
    [ContextMenu("Start Power Flow")]
    public void StartPowerFlow()
    {
        if (powerSource)
        {
            print("Power Flow Started from: " + this.gameObject.name);
            foreach (var node in connectedNodes)
            {
                if (node == this)
                {

                }
                else
                {
                    node.ConnectPowerFlow();
                }
            }
        }
    }

    public void ConnectPowerFlow()
    {
        print(this.gameObject.name + " Power Turned On!");
        ConnectPower();
        foreach (var node in connectedNodes)
        {
            if (!node.connectedToPower)
            {
                node.ConnectPowerFlow();
            }

            if (poweredOn)
            {
                node.poweredOn = true;
            }

        }
    }


    public void ConnectPower()
    {
        powerConnectedIndicator.SetActive(true);
        powerDisconnectedIndicator.SetActive(false);
        connectedToPower = true;


    }

    public void DisconnectPower()
    {
        if (!powerSource)
        {
            powerConnectedIndicator.SetActive(false);
            powerDisconnectedIndicator.SetActive(true);
            connectedToPower = false;
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

    public void PowerOn()
    {
        if (connectedToPower)
        {
            poweredOn = true;
        }
    }

    public void PowerOff()
    {

        poweredOn = false;
        powerConnectedIndicator.transform.rotation = powerDisconnectedIndicator.transform.rotation;

    }

    public void HandleEdit()
    {
        DisconnectPower();
        StartPowerFlow();

    }

    public void HandleZone1PowerOn()
    {
        PowerOn();
    }

    public void HandleZone1PowerOff()
    {
        PowerOff();
    }



}
