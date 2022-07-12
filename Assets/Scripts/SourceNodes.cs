using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceNodes : MonoBehaviour
{
    public Node[] nodes;
    public bool xrayOn;

    public GameObject xrayOnMarker;


    private void Awake()
    {
        InputManager.Instance.onToggleXray.AddListener(ToggleXray);
        XrayCubesOff();
    }

    [ContextMenu("Xray Off")]
    public void XrayCubesOff()
    {
        foreach (var item in nodes)
        {
            item.XrayCubeOff();
        }
        xrayOn = false;
        xrayOnMarker.SetActive(false);
    }

    [ContextMenu("Xray On")]
    public void XrayCubesOn()
    {

        foreach (var item in nodes)
        {
            item.XrayCubeOn();
        }
        xrayOn = true;
        xrayOnMarker.SetActive(true);
    }

    public void ToggleXray()
    {
        if (xrayOn)
        {
            XrayCubesOff();
        }
        else
        {
            XrayCubesOn();
        }
    }

}
