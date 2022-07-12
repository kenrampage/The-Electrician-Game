using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableCollision : MonoBehaviour
{
    public CableTransform cableTransform;

    public string triggerTag;
    public bool isColliding;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == triggerTag)
        {
            isColliding = true;
            cableTransform.isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
        cableTransform.isColliding = false;
    }
}
