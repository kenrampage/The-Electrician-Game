using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManagerRemote : MonoBehaviour
{
    public GameObject powerIndicator;

    // private void Awake()
    // {
    //     if (NodeManager.Instance.powerOn)
    //     {
    //         powerIndicator.SetActive(true);
    //     }
    //     else
    //     {
    //         powerIndicator.SetActive(false);
    //     }
    // }

    [ContextMenu("Turn Power On")]
    public void Zone1PowerOn()
    {
        // NodeManager.Instance.PowerOn();
        powerIndicator.SetActive(true);

    }

    [ContextMenu("Turn Power Off")]
    public void Zone1PowerOff()
    {
        // NodeManager.Instance.PowerOff();
        powerIndicator.SetActive(false);

    }

    // public void Zone1PowerToggle()
    // {
    //     if (NodeManager.Instance.powerOn)
    //     {
    //         Zone1PowerOff();
    //     }
    //     else
    //     {
    //         Zone1PowerOn();
    //     }
    // }
}
