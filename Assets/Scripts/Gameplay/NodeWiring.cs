using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeWiring : MonoBehaviour, IInteractable
{
    private InventoryManager inventoryManager;
    public List<GameObject> powerIndicators;
    // private string targetTag;

    public int currentItemIndex;

    public bool connectedToPower;
    public bool poweredOn;

    public bool isPowerSource;

    public List<GameObject> connectedWires;

    public GameObject powerCablePrefab;

    private void Awake()
    {   
        if(isPowerSource)
        {
            PowerOn();
            connectedToPower = true;
            poweredOn = true;
        }
        inventoryManager = FindObjectOfType<InventoryManager>();
        // targetTag = "Raycast Indicator";
    }

    private void Update()
    {
        if (!isPowerSource)
        {
            CheckConnectedToPower();
            CheckPoweredOn();
        }

    }

    public void Interact()
    {
        if (!inventoryManager.CheckIfRunningCable())
        {
            //creates cable
            GameObject newCable = Instantiate(powerCablePrefab, this.transform.position, this.transform.rotation);
            newCable.GetComponent<PowerCable>().connectedNodes.Add(this.gameObject);

            //add this cable to the list
            connectedWires.Add(newCable);

            //sets start point for cable
            newCable.GetComponent<PowerCable>().HoldCable();

        }
        else
        {
            GameObject heldCable = inventoryManager.heldCable;
            PowerCable heldPowerCable = heldCable.GetComponent<PowerCable>();

            connectedWires.Add(heldCable);
            heldPowerCable.UnholdCable();
            heldPowerCable.SetCableTarget(this.gameObject);
            heldPowerCable.SetEndPointToTarget();
        }

    }

    public void Cancel()
    {

    }

    public void PowerOn()
    {
        foreach (var item in powerIndicators)
        {
            item.SetActive(false);
        }

        powerIndicators[1].SetActive(true);
    }

    public void PowerOff()
    {
        foreach (var item in powerIndicators)
        {
            item.SetActive(false);
        }

        powerIndicators[0].SetActive(true);
    }

    public void CheckConnectedToPower()
    {
        foreach (var item in connectedWires)
        {
            if (item.GetComponent<PowerCable>().connectedToPower)
            {
                connectedToPower = true;
                PowerOn();
                return;
            }
            else
            {
                PowerOff();
            }

        }
    }

    public void CheckPoweredOn()
    {
        foreach (var item in connectedWires)
        {
            if (item.GetComponent<PowerCable>().poweredOn)
            {
                poweredOn = true;
                return;
            }

        }
    }


}
