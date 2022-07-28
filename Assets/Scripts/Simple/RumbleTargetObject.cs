using UnityEngine;

namespace RampageUtils
{
    // Randomizes local position of target object simulating a rumbling effect
    public class RumbleTargetObject : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool _isRumbleOn;
        [SerializeField] private Vector3 _rumbleAmount;

        [Header("References")]
        [SerializeField] private GameObject _rumbleObject;


        private void FixedUpdate()
        {
            if (_isRumbleOn)
            {
                Rumble();
            }
        }

        private void Rumble()
        {
            _rumbleObject.transform.localPosition = new Vector3(Random.Range(-_rumbleAmount.x, _rumbleAmount.x), Random.Range(-_rumbleAmount.y, _rumbleAmount.y), Random.Range(-_rumbleAmount.z, _rumbleAmount.z));
        }

        public void TurnRumbleOn()
        {
            _isRumbleOn = true;
        }

        public void TurnRumbleOff()
        {
            _isRumbleOn = false;
        }
    }
}

