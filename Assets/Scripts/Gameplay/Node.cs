using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Node : MonoBehaviour
{
    private SphereCollider col;

    public GameObject powerConnectedIndicator;
    public GameObject powerDisconnectedIndicator;
    public Vector3 rotateSpeed;

    //track power status
    public bool powerSource;
    public bool connectedToPower;
    public bool poweredOn;

    public bool updatesOn;

    //track installed box
    public List<Node> connectedNodes;

    // public bool updatedThisRound;


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
        // DisconnectPower();
        // StartPowerFlow();

    }

    public void CheckStatusOfConnectedNodes()
    {
        if (!powerSource)
        {
            if (connectedNodes.Count == 0)
            {
                DisconnectPower();
            }
            foreach (var node in connectedNodes)
            {
                if (node.connectedToPower)
                {
                    ConnectPower();
                    if (node.poweredOn)
                    {
                        PowerOn();
                    }
                    break;
                }
                else
                {
                    DisconnectPower();
                }
            }

        }
    }

    private void FixedUpdate()
    {
        if (poweredOn)
        {
            powerConnectedIndicator.transform.Rotate(rotateSpeed, Space.Self);
        }
    }

    // //trigger whenever a change is made
    // [ContextMenu("Start Power Flow")]
    // public void StartPowerFlow()
    // {
    //     if (powerSource)
    //     {
    //         // print("Power Flow Started from: " + this.gameObject.name);
    //         foreach (var node in connectedNodes)
    //         {
    //             node.ConnectPowerFlow();

    //             // if (node == this)
    //             // {

    //             // }
    //             // else
    //             // {
    //             //     node.ConnectPowerFlow();
    //             // }
    //         }
    //     }
    // }

    // [ContextMenu("Connect Power Flow")]
    // public void ConnectPowerFlow()
    // {
    //     ConnectPower();
    //     foreach (var node in connectedNodes)
    //     {
    //         if(!node.updatedThisRound)
    //         {   
    //             print(gameObject.name + " has been updated this round");
    //             node.updatedThisRound = true;
    //             node.ConnectPowerFlow();
    //         }


    //         // if (!node.connectedToPower)
    //         // {
    //         //     node.ConnectPowerFlow();
    //         // }

    //         // if (this.poweredOn)
    //         // {
    //         //     node.poweredOn = true;
    //         // }

    //     }
    // }


    [ContextMenu("Connect Power")]
    public void ConnectPower()
    {

        connectedToPower = true;
        powerConnectedIndicator.SetActive(true);
        powerDisconnectedIndicator.SetActive(false);

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

        poweredOn = true;

    }

    public void PowerOff()
    {

        poweredOn = false;
        powerConnectedIndicator.transform.rotation = powerDisconnectedIndicator.transform.rotation;

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
