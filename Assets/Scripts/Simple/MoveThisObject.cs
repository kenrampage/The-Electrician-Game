using UnityEngine;

namespace RampageUtils
{
    public class MoveThisObject : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool _isMovementOn;
        [SerializeField] private Vector3 _moveSpeed;
        
        private void FixedUpdate()
        {
            if (_isMovementOn)
            {
                Move();
            }
        }

        private void Move()
        {
            transform.Translate(_moveSpeed * Time.deltaTime, Space.World);
        }

        public void TurnMovementOn()
        {
            _isMovementOn = true;
        }

        public void TurnMovementOff()
        {
            _isMovementOn = false;
        }

    }
}
