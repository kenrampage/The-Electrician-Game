using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoweredByNode : MonoBehaviour, IInteractable
{
    public Node node;

    public bool connectedToPower;
    public bool switchedOn;
    public UnityEvent onSwitchedOn;
    public UnityEvent onSwitchedOff;

    private void Awake()
    {
        node.onPowerStatusChanged.AddListener(HandlePowerStatusChanged);
    }

    private void OnEnable()
    {
        if (switchedOn && node.ConnectedToPower)
        {
            onSwitchedOn?.Invoke();
        }

        if (node.ConnectedToPower)
        {
            connectedToPower = true;
        }
    }

    public void SwitchOn()
    {

        switchedOn = true;
    }

    public void SwitchOff()
    {

        switchedOn = false;
    }

    public void HandlePowerStatusChanged()
    {

        connectedToPower = node.ConnectedToPower;
        print(gameObject.name + " connected to power " + connectedToPower);

        if (node.ConnectedToPower && switchedOn)
        {
            onSwitchedOn?.Invoke();
        }
        else if (!node.ConnectedToPower && switchedOn)
        {

            onSwitchedOff?.Invoke();

        }
    }

    public void Interact()
    {
        if (switchedOn & node.ConnectedToPower)
        {
            onSwitchedOff?.Invoke();
            SwitchOff();

        }
        else if (!switchedOn & node.ConnectedToPower)
        {
            onSwitchedOn?.Invoke();
            SwitchOn();
        }
        else if (!node.ConnectedToPower)
        {
            switchedOn = !switchedOn;
        }
    }

    public void Cancel()
    {

    }

}
