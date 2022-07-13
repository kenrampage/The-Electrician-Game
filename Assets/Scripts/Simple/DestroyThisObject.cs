using UnityEngine;

namespace RampageUtils
{

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

