using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableHelper : MonoBehaviour
{
    [SerializeField] private UnityEvent onEnable;
    [SerializeField] private float delay;

    private void OnEnable()
    {
        StartCoroutine(InvokeEvent());
    }

    private IEnumerator InvokeEvent()
    {
        yield return new WaitForSecondsRealtime(delay);
        onEnable?.Invoke();
    }
}
