using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SerializedEvents
{
    public float delay;
    public UnityEvent serializedEvents;
    
    public void InvokeEvent()
    {
        serializedEvents?.Invoke();
    }

}
