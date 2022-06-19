using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMarkers : MonoBehaviour
{
    public GameObject[] indicators;
    public bool indicatorsOn;
    public Vector3 rotateSpeed;

    private void FixedUpdate()
    {
        if (indicatorsOn)
        {
            foreach (var item in indicators)
            {
                item.transform.Rotate(rotateSpeed, Space.Self);
            }
        }
    }
}
