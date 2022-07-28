using UnityEngine;
using UnityEngine.Events;

namespace RampageUtils
{
    // Reusable timer class that invokes event on completion
    public class Timer : MonoBehaviour
    {
        [Header("Events")]
        public UnityEvent OnTimerDone;

        [Header("Settings")]
        [SerializeField] private bool _isTimerOn = false;
        [SerializeField] private float _startTime;

        private float _currentTime;
        private float _percentComplete;

        private void Awake()
        {
            ResetTimer();
        }

        private void Update()
        {
            if (_isTimerOn)
            {
                TimerCountdown();
            }
        }

        public void TurnTimerOn()
        {
            _isTimerOn = true;
        }

        public void TurnTimerOff()
        {
            _isTimerOn = false;
        }

        private void TimerCountdown()
        {
            _currentTime -= Time.deltaTime;
            _percentComplete = _currentTime / _startTime;

            if (_currentTime <= 0)
            {
                TimerDone();
            }
        }

        private void ResetTimer()
        {
            _currentTime = _startTime;
        }

        private void TimerDone()
        {
            ResetTimer();
            OnTimerDone?.Invoke();
        }

    }
}
