using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManagerRemote : MonoBehaviour
{
    public GameObject powerIndicator;

    private void Awake()
    {
        if (NodeManager.Instance.zone1PowerOn)
        {
            powerIndicator.SetActive(true);
        }
        else
        {
            powerIndicator.SetActive(false);
        }
    }

    [ContextMenu("Turn Power On")]
    public void Zone1PowerOn()
    {
        NodeManager.Instance.OnZone1PowerOn();
        powerIndicator.SetActive(true);

    }

    [ContextMenu("Turn Power Off")]
    public void Zone1PowerOff()
    {
        NodeManager.Instance.OnZone1PowerOff();
        powerIndicator.SetActive(false);

    }

    public void Zone1PowerToggle()
    {
        if (NodeManager.Instance.zone1PowerOn)
        {
            Zone1PowerOff();
        }
        else
        {
            Zone1PowerOn();
        }
    }
}
