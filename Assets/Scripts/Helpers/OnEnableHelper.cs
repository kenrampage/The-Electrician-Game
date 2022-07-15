using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace RampageUtils.Helpers
{
    // Invoke Unity Event on object enabled with customizable delay
    public class OnEnableHelper : MonoBehaviour
    {
        [Header("Event")]
        [SerializeField] private UnityEvent OnInvoke;

        [Header("Settings")]
        [SerializeField] private float _delay;

        private void OnEnable()
        {
            StartCoroutine(InvokeEvent());
        }

        private IEnumerator InvokeEvent()
        {
            yield return new WaitForSecondsRealtime(_delay);
            OnInvoke?.Invoke();
        }
    }
}
