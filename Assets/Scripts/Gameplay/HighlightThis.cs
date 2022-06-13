using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightThis : MonoBehaviour
{
    private Material material;

    private string targetTag;

    private void Awake()
    {
        targetTag = "Cursor";
        material = GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == targetTag)
        {
            SelectThis();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == targetTag)
        {
            DeselectThis();
        }
        
    }


    [ContextMenu("Select This")]
    public void SelectThis()
    {
        print(gameObject.name + " Selected");
        material.EnableKeyword("_EMISSION");
    }

    [ContextMenu("Deselect This")]
    public void DeselectThis()
    {
        print(gameObject.name + " Deselected");
        material.DisableKeyword("_EMISSION");
    }

}
