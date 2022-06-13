using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private SphereCollider col;

    //track power status
    public bool connectedToPower;
    public bool poweredOn;

    //track installed box
    public WiringBox installedBox;

    private LayerMask cableLayerMask;

    private void Awake()
    {
        col = GetComponent<SphereCollider>();
    }

    //check if any cables colliding with this node are connected to power
    public void CheckCablePower()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, col.radius, cableLayerMask);

        foreach (var c in colliders)
        {
            if (c.GetComponent<Cable>().connectedToPower)
            {
                connectedToPower = true;
                break;
            }
            else
            {
                connectedToPower = false;
            }
        }
    }



}
