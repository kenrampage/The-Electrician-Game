using UnityEngine;

namespace RampageUtils
{
    // Toggles active status of target object
    public class ToggleTargetObject : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject _targetObject;

        public void SetActive()
        {
            _targetObject.SetActive(true);
        }

        public void SetInactive()
        {
            _targetObject.SetActive(false);
        }

        public void ToggleActive()
        {
            if(_targetObject.activeSelf)
            {
                SetInactive();
            } else
            {
                SetActive();
            }
        }

    }
}
