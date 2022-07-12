using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InvokeEventAfterDelay : MonoBehaviour
{
    public UnityEvent unityEvent;
    public float delay;

    public void InvokeEvent(float f)
    {
        StartCoroutine(InvokeEventCoroutine(f));
    }

    public IEnumerator InvokeEventCoroutine(float f)
    {
        yield return new WaitForSecondsRealtime(f);
        unityEvent?.Invoke();
    }
}
