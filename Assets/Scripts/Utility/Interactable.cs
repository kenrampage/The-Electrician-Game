using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    public UnityEvent onInteractionA;
    public UnityEvent onInteractionB;


    public void InteractA()
    {
        InvokeEventA();
    }

    [ContextMenu("Test Event")]
    public void InvokeEventA()
    {
        onInteractionA?.Invoke();
    }

    public void InteractB()
    {
        InvokeEventB();
    }

    [ContextMenu("Test Event")]
    public void InvokeEventB()
    {
        onInteractionB?.Invoke();
    }
}
