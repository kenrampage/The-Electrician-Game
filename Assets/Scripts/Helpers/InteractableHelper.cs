using UnityEngine;
using UnityEngine.Events;

// Helper to handle IInteractable activity and translate into serializable unity events
namespace RampageUtils.Interfaces
{
    public class InteractableHelper : MonoBehaviour, IInteractable
    {
        [Header("Events")]
        public UnityEvent OnInteract;
        public UnityEvent OnCancel;

        public void Interact()
        {
            OnInteract?.Invoke();
        }

        public void Cancel()
        {
            OnCancel?.Invoke();
        }
    }
}
