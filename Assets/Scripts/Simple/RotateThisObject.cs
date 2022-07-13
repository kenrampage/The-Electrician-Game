using UnityEngine;
using UnityEngine.Serialization;

namespace RampageUtils
{
    public class RotateThisObject : MonoBehaviour
    {
        [FormerlySerializedAs("rotation")]
        [SerializeField] private Vector3 _rotation;

        [FormerlySerializedAs("rotationOn")]
        [SerializeField] private bool _isRotationOn;

        private void FixedUpdate()
        {
            if (_isRotationOn)
            {
                Rotate();
            }
        }

        private void Rotate()
        {
            transform.Rotate(_rotation, Space.Self);
        }


        public void TurnRotationOn()
        {
            _isRotationOn = true;
        }

        public void TurnRotationOff()
        {
            _isRotationOn = false;
        }
    }
}
