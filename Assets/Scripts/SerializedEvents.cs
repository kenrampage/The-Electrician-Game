using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SerializedEvents
{
    public UnityEvent serializedEvents;
    public float delay;

    public void InvokeEvent()
    {
        serializedEvents?.Invoke();
    }

}
