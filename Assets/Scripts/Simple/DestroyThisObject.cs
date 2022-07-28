using UnityEngine;

namespace RampageUtils
{
    // Destroy this object after customizable delay
    public class DestroyThisObject : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool _destroyOnEnable;
        [SerializeField] private float _delay;

        private void OnEnable()
        {
            if (_destroyOnEnable)
            {
                DestroyThis();
            }
        }

        public void DestroyThis()
        {
            Destroy(this.gameObject, _delay);
        }

    }

}

