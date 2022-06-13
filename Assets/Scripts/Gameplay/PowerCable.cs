using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCable : MonoBehaviour, IInteractable
{
    private InventoryManager inventoryManager;
    public List<GameObject> connectedNodes;
    public bool connectedToPower;
    public bool poweredOn;
    public LineRenderer lineRenderer;
    private string targetTag;

    public bool currentlyHeld = false;
    public bool currentlySnapped = false;

    public GameObject cableHolder;

    public GameObject cableTarget;

    public Material lineMaterial;


    private void Awake()
    {
        targetTag = "Raycast Indicator";
        lineRenderer = GetComponent<LineRenderer>();
        lineMaterial = lineRenderer.material;
    }

    private void OnEnable()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        cableHolder = GameObject.FindWithTag("Cable Holder");
        
    }

    private void OnDisable()
    {

    }

    private void Update()
    {
        if (currentlySnapped)
        {
            SetEndPoint(cableTarget.transform.position);
           
        }
        else if (currentlyHeld)
        {
            SetEndPoint(GetCableTargetRelativePos(cableHolder.transform.position));
        }
        else 
        { 

        }

        CheckConnectedToPower();
        CheckPoweredOn();
    }

    public void SetStartPoint(Vector3 position)
    {
        lineRenderer.SetPosition(0, position);
        HoldCable();
    }

    public void SetEndPoint(Vector3 position)
    {
        lineRenderer.SetPosition(1, position);
    }

    public void SetEndPointToTarget()
    {
        lineRenderer.SetPosition(1, GetCableTargetRelativePos(cableTarget.transform.position));
    }

    public void HoldCable()
    {
        cableTarget = cableHolder;
        currentlyHeld = true;
        inventoryManager.heldCable = this.gameObject;
    }

    public void UnholdCable()
    {
        currentlyHeld = false;
        inventoryManager.heldCable = null;
    }

    public void DestroyCable()
    {
        Destroy(this);
    }

    public void SetCableTarget(GameObject target)
    {
        cableTarget = target;
    }

    public Vector3 GetCableTargetRelativePos(Vector3 targetPos)
    {
        Vector3 pos = targetPos - transform.position;
        return pos;
    }

    public void CheckConnectedToPower()
    {
        foreach (var item in connectedNodes)
        {
            if (item.GetComponent<NodeWiring>().connectedToPower)
            {
                connectedToPower = true;
            }
        }
    }

    public void CheckPoweredOn()
    {
        foreach (var item in connectedNodes)
        {
            if (item.GetComponent<NodeWiring>().poweredOn)
            {
                poweredOn = true;
            }
        }
    }

    // public void HighlightCableOn()
    // {
    //     lineMaterial.EnableKeyword("_EMISSION");
    // }

    // public void HighlightCableOff()
    // {
    //     lineMaterial.DisableKeyword("_EMISSION");
    // }


    // private void OnTriggerEnter(Collider other)
    // {
    //     if (!currentlyHeld && !currentlySnapped)
    //     {
    //         if (other.tag == targetTag)
    //         {
    //             HighlightCableOn();
    //         }
    //     }

    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (!currentlyHeld && !currentlySnapped)
    //     {
    //         if (other.tag == targetTag)
    //         {
    //             HighlightCableOff();
    //         }
    //     }



    // }

    public void Interact()
    {

    }

    public void Cancel()
    {

    }

}
