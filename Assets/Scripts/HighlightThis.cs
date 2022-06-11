using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightThis : MonoBehaviour
{
    private Material material;
    private Collider col;
    private string targetTag;

    private void Awake()
    {
        targetTag = "Raycast Indicator";
        material = GetComponent<MeshRenderer>().material;
        col = GetComponent<Collider>();
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
        material.EnableKeyword("_EMISSION");
    }

    [ContextMenu("Deselect This")]
    public void DeselectThis()
    {
        material.DisableKeyword("_EMISSION");
    }

}
