using UnityEngine;

namespace RampageUtils
{
    // Toggles active status of target objects
    public class ToggleTargetObjects : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject[] _targetObjects;

        public void SetActive()
        {
            foreach (var obj in _targetObjects)
            {
                obj.SetActive(true);
            }
        }

        public void SetInactive()
        {
            foreach (var obj in _targetObjects)
            {
                obj.SetActive(false);
            }

        }

    }
}
