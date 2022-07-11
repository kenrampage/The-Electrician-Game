using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapActiveObject : MonoBehaviour
{

    [SerializeField] private GameObject[] objects;

    private void AllObjectsOff()
    {
        foreach (var item in objects)
        {
            item.SetActive(false);
        }
    }

    public void ActivateObjectAtIndex(int i)
    {
        AllObjectsOff();
        objects[i].SetActive(true);
    }
}
