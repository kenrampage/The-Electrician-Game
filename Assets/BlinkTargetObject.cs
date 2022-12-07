using System.Collections;
using UnityEngine;

public class BlinkTargetObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _targetObject;

    [Header("Settings")]
    [SerializeField] private bool _blinkingActive;
    [SerializeField] private int _numberOfBlinks;
    [SerializeField] private float _blinkDuration;
    [SerializeField] private float _blinkInterval;
    [SerializeField] private float _blinkBreak;

    private void Awake()
    {
        _targetObject.SetActive(false);

        if (_blinkingActive)
        {
            StartBlinking();
        }
    }

    private IEnumerator BlinkCoroutine()
    {
        for (int i = 0; i < _numberOfBlinks; i++)
        {
            _targetObject.SetActive(true);

            yield return new WaitForSeconds(_blinkDuration);

            _targetObject.SetActive(false);

            yield return new WaitForSeconds(_blinkInterval);
        }

        yield return new WaitForSeconds(_blinkBreak);

        StartCoroutine(BlinkCoroutine());

    }

    public void StartBlinking()
    {
        StartCoroutine(BlinkCoroutine());
    }

    public void StopBlinking()
    {
        StopCoroutine(BlinkCoroutine());
    }
}
