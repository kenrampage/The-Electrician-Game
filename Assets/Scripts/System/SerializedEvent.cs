using UnityEngine.Events;

// Used by gamestate manager to serialize a list of events to run with customizable delay between steps
[System.Serializable]
public class SerializedEvent
{
    public float delay;
    public UnityEvent Events;
    
    public void InvokeEvent()
    {
        Events?.Invoke();
    }
}