using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _poolSize;

    [Header("Pool")]
    [SerializeField] private Queue<GameObject> _pool = new Queue<GameObject>();

    private void Awake()
    {
        SpawnObjectsIntoPool();
    }

    private void SpawnObjectsIntoPool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(_prefab, this.transform);
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public void RetrieveObject(Vector3 position, Quaternion rotation)
    {
        GameObject obj;
        _pool.TryDequeue(out obj);

        obj.SetActive(true);
        obj.transform.SetPositionAndRotation(position, rotation);

        ObjectPoolerRemote objectPoolerRemote = obj.GetComponent<ObjectPoolerRemote>();

        if (objectPoolerRemote != null)
        {
            objectPoolerRemote.SetSourcePooler(this);
            objectPoolerRemote.OnObjectRetrieved();
        }

    }

    public void ReturnObject(GameObject obj)
    {
        _pool.Enqueue(obj);
        obj.SetActive(false);
    }
}
