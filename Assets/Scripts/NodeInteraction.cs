using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInteraction : MonoBehaviour, IInteractable
{
    private InventoryManager inventoryManager;
    private Node node;

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
            cable.cableTransform.SetStartPosition(transform.position);
            cable.cableTransform.StartEditing();

            // //When creating cable, add all connected nodes and cables from the source node to the cable's list
            // // AddToCableConnectedLists();

            // // add this cable to cable lists
            // node.AddConnectedCable(cable);
            // cable.AddConnectedCable(cable);

            // //add this node to node lists
            // cable.AddConnectedNode(node);
            // node.AddConnectedNode(node);

            // //add nodes connected to the node to the cable's node list
            // foreach (var n in node.connectedNodeList)
            // {
            //     cable.AddConnectedNode(n);
            // }

            // //add cables connected to the node to the cable's cable list
            // foreach (var c in node.connectedCableList)
            // {
            //     cable.AddConnectedCable(c);
            // }

            // //add nodes connected to the cable to the node's node list
            // foreach (var n in cable.connectedNodeList)
            // {
            //     node.AddConnectedNode(n);
            // }

            // //add cables connected to the cable to the node's cable list
            // foreach (var c in cable.connectedCableList)
            // {
            //     node.AddConnectedCable(c);
            // }

            // //add newly connected nodes and cables to the cables connected nodes
            // foreach (var n in cable.connectedNodeList)
            // {
            //     n.AddConnectedCable(cable);
            //     n.AddConnectedNode(node);
            // }

            // //add newly connected nodes and cables to the nodes connected nodes
            // foreach (var n in node.connectedNodeList)
            // {
            //     n.AddConnectedCable(cable);
            //     n.AddConnectedNode(node);
            // }

            // //add newly connected nodes and cables to the cables connected cables
            // foreach (var c in cable.connectedCableList)
            // {
            //     c.AddConnectedCable(cable);
            //     c.AddConnectedNode(node);
            // }

            // //add newly connected nodes and cables to the nodes connected cables
            // foreach (var c in node.connectedCableList)
            // {
            //     c.AddConnectedCable(cable);
            //     c.AddConnectedNode(node);
            // }

        }
        else if (inventoryManager.CurrentIndex == 7 && inventoryManager.editingCable) //Already holding cable and installing at second point
        {
            var cable = inventoryManager.heldCable.GetComponent<Cable>();

            //set end point of cable to node
            cable.cableTransform.SetEndPosition(this.transform.position);

            //turn off cable editing
            cable.cableTransform.EndEditing();
            cable.cableTransform.EndPreview();
            inventoryManager.editingCable = false;

            // if (cable.CheckNodeOnList(node))
            // {
            //     return;
            // }

            // // add this cable to cable lists
            // node.AddConnectedCable(cable);
            // cable.AddConnectedCable(cable);

            // //add this node to node lists
            // cable.AddConnectedNode(node);
            // node.AddConnectedNode(node);

            // //add nodes connected to the node to the cable's node list
            // foreach (var n in node.connectedNodeList)
            // {
            //     cable.AddConnectedNode(n);
            // }

            // //add cables connected to the node to the cable's cable list
            // foreach (var c in node.connectedCableList)
            // {
            //     cable.AddConnectedCable(c);
            // }

            // //add nodes connected to the cable to the node's node list
            // foreach (var n in cable.connectedNodeList)
            // {
            //     node.AddConnectedNode(n);
            // }

            // //add cables connected to the cable to the node's cable list
            // foreach (var c in cable.connectedCableList)
            // {
            //     node.AddConnectedCable(c);
            // }

            // //add newly connected nodes and cables to the cables connected nodes
            // foreach (var n in cable.connectedNodeList)
            // {
            //     n.AddConnectedCable(cable);
            //     n.AddConnectedNode(node);
            // }

            // //add newly connected nodes and cables to the nodes connected nodes
            // foreach (var n in node.connectedNodeList)
            // {
            //     n.AddConnectedCable(cable);
            //     n.AddConnectedNode(node);
            // }

            // //add newly connected nodes and cables to the cables connected cables
            // foreach (var c in cable.connectedCableList)
            // {
            //     c.AddConnectedCable(cable);
            //     c.AddConnectedNode(node);
            // }

            // //add newly connected nodes and cables to the nodes connected cables
            // foreach (var c in node.connectedCableList)
            // {
            //     c.AddConnectedCable(cable);
            //     c.AddConnectedNode(node);
            // }

        }
    }

    public void Cancel()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if editing cable
        if (inventoryManager.CurrentIndex == 7 && inventoryManager.editingCable)
        {
            var cable = inventoryManager.heldCable.GetComponent<Cable>();
            cable.cableTransform.StartPreview(transform.position);

            // // check if the held cable is already connected to this node
            // if (!cable.CheckNodeOnList(node))
            // {
            //     //While in trigger snap end position to node
            //     cable.cableTransform.StartPreview(transform.position);
            // }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if editing cable
        if (inventoryManager.CurrentIndex == 7 && inventoryManager.editingCable)
        {
            var cable = inventoryManager.heldCable.GetComponent<Cable>();


            //While in trigger snap end position to node
            cable.cableTransform.EndPreview();

        }
    }


}
