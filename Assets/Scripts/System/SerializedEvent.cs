using UnityEngine.Events;
using UnityEngine;

// Used by gamestate manager to serialize a list of events to run with customizable delay between steps
[System.Serializable]
public class SerializedEvent
{
    [Header("Settings")]
    public float Delay;

    [Header("Events")]
    public UnityEvent Event;
    
    public void InvokeEvent()
    {
        Event?.Invoke();
    }
}