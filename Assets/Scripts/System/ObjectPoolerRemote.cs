using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPoolerRemote : MonoBehaviour
{
    private ObjectPooler _objectPooler;

    [Header("Events")]
    [SerializeField] private UnityEvent onObjectRetrieved;

    public void SetSourcePooler(ObjectPooler objectPooler)
    {
        _objectPooler = objectPooler;
    }

    public void ReturnObject()
    {
        _objectPooler.ReturnObject(this.gameObject);
    }

    public void OnObjectRetrieved()
    {
        onObjectRetrieved?.Invoke();
    }
}
