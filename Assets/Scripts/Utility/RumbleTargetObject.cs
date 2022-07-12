using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleTargetObject : MonoBehaviour
{

    [SerializeField] private Vector3 rumbleAmount;
    [SerializeField] private bool isRumbleOn;
    [SerializeField] private GameObject rumbleObject;


    private void FixedUpdate()
    {
        if(isRumbleOn)
        {
            Rumble();
        }
    }

    private void Rumble()
    {
        rumbleObject.transform.localPosition = new Vector3(Random.Range(-rumbleAmount.x, rumbleAmount.x), Random.Range(-rumbleAmount.y, rumbleAmount.y), Random.Range(-rumbleAmount.z, rumbleAmount.z));
    }

    public void TurnRumbleOn()
    {
        isRumbleOn = true;
    }

    public void TurnRumbleOff()
    {
        isRumbleOn = false;
    }
}
