using UnityEngine;

namespace RampageUtils
{
    // Rotate this object on specified direction and speed
    public class RotateThisObject : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Vector3 _rotation;
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
