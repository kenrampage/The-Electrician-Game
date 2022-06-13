using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    public UnityEvent onInteraction;
    public UnityEvent onCancel;


    public void Interact()
    {
        InvokeEventA();
    }


    [ContextMenu("Test Event")]
    public void InvokeEventA()
    {
        onInteraction?.Invoke();
    }


    public void Cancel()
    {
        InvokeEventB();
    }

    [ContextMenu("Test Event")]
    public void InvokeEventB()
    {
        onCancel?.Invoke();
    }
}
