using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBox : MonoBehaviour, IInteractable
{
    private InventoryManager inventoryManager;

    public List<GameObject> nodePreviewObjects;
    public List<GameObject> nodePrefabs;

    public GameObject nodeCompass;

    public int previewNodeIndex;
    public GameObject installedNode;
    public int installedNodeIndex;

    private string targetTag;

    public int currentItemIndex;

    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        targetTag = "Raycast Indicator";
    }

    private void OnEnable()
    {
        inventoryManager.onItemChanged += UpdatePreview;
    }

    private void OnDisable()
    {
        inventoryManager.onItemChanged -= UpdatePreview;
    }

    private void UpdatePreview()
    {
        currentItemIndex = inventoryManager.CurrentIndex;
        previewNodeIndex = TransposeIndexes(currentItemIndex);
        PreviewOff();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
        {
            currentItemIndex = inventoryManager.CurrentIndex;
            previewNodeIndex = TransposeIndexes(currentItemIndex);
            PreviewOn();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        PreviewOn();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == targetTag)
        {
            PreviewOff();
        }

    }

    public void InteractA()
    {
        // print("InteractA on " + gameObject.name);
        //checks if installednode is null
        if (installedNode != null)
        {
            print("Node already installed!");
            return;
        }

        if (inventoryManager.CheckInventory(currentItemIndex))
        {
            InstallNode();
        }


        //turns off preview
        PreviewOff();

    }

    public void InteractB()
    {
        // print("InteractB on " + gameObject.name);
        RemoveNode();
    }

    public void InstallNode()
    {
        //sets installednode variable and installed the node box

        installedNode = Instantiate(nodePrefabs[previewNodeIndex], nodeCompass.transform.position, nodeCompass.transform.rotation);
        installedNode.transform.LookAt(this.transform);
        installedNodeIndex = currentItemIndex;

        //decrease inventory by 1
        inventoryManager.DecrementInventory(installedNodeIndex);
    }

    public void RemoveNode()
    {
        //increase inventory
        inventoryManager.IncrementInventory(installedNodeIndex);

        //destroys node object
        Destroy(installedNode);

        //clears installednode variable
        installedNode = null;
    }

    [ContextMenu("Preview On")]
    public void PreviewOn()
    {
        if (installedNode == null)
        {
            GameObject previewObject = nodePreviewObjects[previewNodeIndex];

            //move box to this location
            previewObject.transform.position = nodeCompass.transform.position;

            previewObject.transform.LookAt(this.transform);

            //turn on box game object
            nodePreviewObjects[previewNodeIndex].SetActive(true);
        }

    }

    [ContextMenu("Preview OFf")]
    public void PreviewOff()
    {

        //turn off box game object
        // nodePreviewObjects[previewNodeIndex].SetActive(false);
        foreach (var item in nodePreviewObjects)
        {
            item.SetActive(false);
        }



    }


    //Update the case statements here to reflect the indexes of the 3 node items in inventory
    private int TransposeIndexes(int i)
    {
        switch (i)
        {
            case 4:
                return 0;


            case 5:
                return 1;


            case 6:
                return 2;


            default:
                return 0;

        }

    }
}
