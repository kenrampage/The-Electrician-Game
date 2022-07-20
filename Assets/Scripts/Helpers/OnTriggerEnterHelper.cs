using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace RampageUtils.Helpers
{
    // On trigger enter invokes event if other object's tag is contained in _targetTags array, or if _targetTags is null
    public class OnTriggerEnterHelper : MonoBehaviour
    {
        [Header("Event")]
        public UnityEvent OnInvoke;

        [Header("Settings")]
        [SerializeField] private float _delay;
        [SerializeField] private string[] _targetTags;

        private void OnTriggerEnter(Collider other)
        {
            if(CheckTargetTags(other.gameObject))
            {
                InvokeEvent();
            }
        }

        private bool CheckTargetTags(GameObject gameObject)
        {
            if (_targetTags == null)
            {
                return true;
            }
            else
            {
                foreach (var tag in _targetTags)
                {
                    if (gameObject.CompareTag(tag))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private void InvokeEvent()
        {
            StartCoroutine(InvokeEventCoroutine());
        }

        private IEnumerator InvokeEventCoroutine()
        {
            yield return new WaitForSecondsRealtime(_delay);
            OnInvoke?.Invoke();
        }
    }
}
