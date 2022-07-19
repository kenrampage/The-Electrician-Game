using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightCable : MonoBehaviour
{
    private Material material;

    private string targetTag;

    private void Awake()
    {
        targetTag = "Cursor";
        // material = GetComponent<MeshRenderer>().material;
    }

    private void OnEnable()
    {
        DeselectThis();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
        {
            // print("triggered by Cursor");
            SelectThis();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == targetTag)
        {
            DeselectThis();
        }

    }


    [ContextMenu("Select This")]
    public void SelectThis()
    {
        if (InventoryManager.Instance._isHoldingCable)
        {
            return;
        }
        material = GetComponent<MeshRenderer>().material;
        material.EnableKeyword("_EMISSION");
    }

    [ContextMenu("Deselect This")]
    public void DeselectThis()
    {
        material = GetComponent<MeshRenderer>().material;
        material.DisableKeyword("_EMISSION");
    }

}
