using UnityEngine;
using UnityEngine.Events;

namespace RampageUtils.Interfaces
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        [Header("Events")]
        public UnityEvent OnInteract;
        public UnityEvent OnCancel;


        public void Interact()
        {
            InvokeInteractEvent();
        }

        public void InvokeInteractEvent()
        {
            OnInteract?.Invoke();
        }

        public void Cancel()
        {
            InvokeCancelEvent();
        }

        public void InvokeCancelEvent()
        {
            OnCancel?.Invoke();
        }
    }
}
