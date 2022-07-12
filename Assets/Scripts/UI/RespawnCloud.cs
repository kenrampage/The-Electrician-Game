using UnityEngine;

public class RespawnCloud : MonoBehaviour
{
    [SerializeField] private BoxCollider respawnArea;

    private void OnTriggerEnter(Collider other)
    {
        print("respawned cloud");
        other.transform.position = GetRandomPointInsideCollider(respawnArea);
    }

    public Vector3 GetRandomPointInsideCollider(BoxCollider boxCollider)
    {
        Vector3 extents = boxCollider.size / 2f;

        Vector3 point = new Vector3(
            Random.Range(-extents.x, extents.x),
            Random.Range(-extents.y, extents.y),
            Random.Range(-extents.z, extents.z)
        ) + boxCollider.center;

        return boxCollider.transform.TransformPoint(point);
    }
}
