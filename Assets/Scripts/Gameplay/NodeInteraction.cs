using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInteraction : MonoBehaviour, IInteractable
{
    private InventoryManager inventoryManager;
    public Node node;

    public GameObject cablePrefab;

    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        node = GetComponent<Node>();
    }

    public void Interact()
    {
        //Check which object player is holding

        if (inventoryManager.CurrentIndex == 7 && !inventoryManager.editingCable) //Installing cable at first point
        {
            //creates cable
            var newCable = Instantiate(cablePrefab, transform.position, transform.rotation);
            var cable = newCable.GetComponent<Cable>();

            //sets this cable as currently held cable
            inventoryManager.heldCable = newCable;
            inventoryManager.editingCable = true;

            //sets start point for cable
            cable.SetSourceNode(node);

            cable.cableTransform.SetStartPosition(transform.position);
            cable.cableTransform.EditModeOn();

        }
        else if (inventoryManager.CurrentIndex == 7 && inventoryManager.editingCable) //Already holding cable and installing at second point
        {
            var cable = inventoryManager.heldCable.GetComponent<Cable>();

            if (node.connectedNodes.Contains(cable.sourceNode))
            {
                return;
            }

            //set end point of cable to node
            cable.cableTransform.SetEndPosition(this.transform.position);

            //turn off cable editing

            node.AddConnectedNode(cable.sourceNode);
            cable.sourceNode.AddConnectedNode(node);
            cable.SetEndNode(node);
            cable.cableTransform.Install();

            inventoryManager.editingCable = false;

        }
    }

    public void Cancel()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if editing cable
        if (inventoryManager.CurrentIndex == 7 && inventoryManager.editingCable && other.tag == "Cursor")
        {
            var cable = inventoryManager.heldCable.GetComponent<Cable>();

            if (!node.connectedNodes.Contains(cable.sourceNode)) //check if the currently held cable has a source node thats on the node.connectednodes list.
            {
                cable.cableTransform.PreviewModeOn(transform.position);

            }



        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if editing cable
        if (inventoryManager.CurrentIndex == 7 && inventoryManager.editingCable && other.tag == "Cursor")
        {
            var cable = inventoryManager.heldCable.GetComponent<Cable>();


            //While in trigger snap end position to node
            cable.cableTransform.PreviewModeOff();
            cable.cableTransform.EditModeOn();

        }
    }


    //Check what cables are currently colliding with this node
    //use a box collider for each node to dictate which other nodes this node can connect to
    //you cant connect a wire to this node if the wire's starting node is already connected to this node

    //when a cable is placed in keeps track of its source node,
    //when a cable is connected to another node it tells the source node what the end node is, and vice versa
    //


}