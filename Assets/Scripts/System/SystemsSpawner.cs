using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SystemEntry
{
    public string Tag;
    public GameObject Prefab;
}

public class SystemsSpawner : MonoBehaviour
{
    [SerializeField] private SystemEntry[] _systems;

    private void Awake()
    {
        SpawnSystems();
    }

    [ContextMenu("Spawn Systems")]
    private void SpawnSystems()
    {
        foreach (var entry in _systems)
        {
            if (GameObject.FindGameObjectWithTag(entry.Tag) == null)
            {
                Instantiate(entry.Prefab);
            }
            else
            {
                // print("Object with Tag of " + entry.Tag + " already exists");
                return;
            }
        }
    }
}
