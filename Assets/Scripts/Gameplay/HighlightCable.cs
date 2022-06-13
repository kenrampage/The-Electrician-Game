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
        material = GetComponent<MeshRenderer>().material;
    }

    private void OnEnable()
    {
        DeselectThis();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
        {
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
        if (InventoryManager.Instance.editingCable)
        {
            return;
        }
        material.EnableKeyword("_EMISSION");
    }

    [ContextMenu("Deselect This")]
    public void DeselectThis()
    {
        material.DisableKeyword("_EMISSION");
    }

}
