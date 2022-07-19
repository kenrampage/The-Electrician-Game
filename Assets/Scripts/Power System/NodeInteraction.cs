using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInteraction : MonoBehaviour, IInteractable
{
    private InventoryManager inventoryManager;
    public Node node;

    public GameObject cablePrefab;

    public int wiringItemIndex;

    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        node = GetComponent<Node>();
    }

    public void Interact()
    {
        //Check which object player is holding

        if (inventoryManager.CurrentIndex == wiringItemIndex && !inventoryManager._isHoldingCable) //Installing cable at first point
        {
            //creates cable
            var newCable = Instantiate(cablePrefab, transform.position, transform.rotation);
            var cable = newCable.GetComponent<Cable>();

            //sets this cable as currently held cable
            inventoryManager.PickupCable(newCable);
            cable.ConnectToSourceNode(node);

        }
        else if (inventoryManager.CurrentIndex == wiringItemIndex && inventoryManager._isHoldingCable) //Already holding cable and installing at second point
        {
            Cable cable = inventoryManager.heldCable.GetComponent<Cable>();

            if (node.connectedNodes.Contains(cable.GetSourceNode()) || node == cable.GetSourceNode() || cable.CollisionCheck())
            {
                return;
            }
            else if (!node.connectedNodes.Contains(cable.GetSourceNode()) && node != cable.GetSourceNode() && !cable.CollisionCheck())
            {
                cable.ConnectToEndNode(node);
                node.HighlightOff();
            }

        }
    }

    public void Cancel()
    {
        // Implemented for IInteractable interface
    }

    private void OnTriggerEnter(Collider other)
    {
        if (inventoryManager.CurrentIndex == wiringItemIndex && !inventoryManager._isHoldingCable && other.tag == "Cursor")
        {
            node.HighlightOn();

        }
        else if (inventoryManager.CurrentIndex == wiringItemIndex && inventoryManager._isHoldingCable && other.tag == "Cursor")
        {
            node.HighlightOn();
            Cable cable = inventoryManager.heldCable.GetComponent<Cable>();

            //check if the currently held cable has a source node that is this node or ison the node.connectednodes list.
            if (!node.connectedNodes.Contains(cable.GetSourceNode()) && this.gameObject != cable.GetSourceNode())
            {
                cable.PreviewAtEndNodeOn(node);
            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (inventoryManager.CurrentIndex == wiringItemIndex && !inventoryManager._isHoldingCable && other.tag == "Cursor")
        {
            node.HighlightOff();

        }
        else if (inventoryManager.CurrentIndex == wiringItemIndex && inventoryManager._isHoldingCable && other.tag == "Cursor")
        {
            node.HighlightOff();
            var cable = inventoryManager.heldCable.GetComponent<Cable>();

            cable.PreviewAtEndNodeOff(node);
        }
    }

}
