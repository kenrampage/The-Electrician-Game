using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : Singleton<PowerManager>
{
    // //track all nodes and power status
    // public List<Node> nodeList;

    public delegate void UpdateStatusAction();
    public event UpdateStatusAction onUpdateStatusTriggered;

    public delegate void PowerOnAction();
    public event PowerOnAction onPowerOnTriggered;

    public delegate void PowerOffAction();
    public event PowerOffAction onPowerOffTriggered;

    public void UpdateStatus()
    {
        onUpdateStatusTriggered?.Invoke();
    }

    public void PowerOn()
    {
        onPowerOnTriggered?.Invoke();
    }

    public void PowerOff()
    {
        onPowerOffTriggered?.Invoke();
    }

}
