using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class NodeManager : Singleton<NodeManager>
{
    //track all target nodes and their power status
    //once all target nodes are powered on you win

    public bool zone1PowerOn;

    public UnityEvent onEdit;
    public UnityEvent onZone1PowerOn;
    public UnityEvent onZone1PowerOff;

    public void OnEdit()
    {
        onEdit?.Invoke();
    }

    public void OnZone1PowerOn()
    {
        zone1PowerOn = true;
        onZone1PowerOn?.Invoke();
    }

    public void OnZone1PowerOff()
    {
        zone1PowerOn = false;
        onZone1PowerOff?.Invoke();
    }



}
