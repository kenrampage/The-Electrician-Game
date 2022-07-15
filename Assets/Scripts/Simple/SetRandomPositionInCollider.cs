using UnityEngine;

// Sets this objects position to a random point within target box collider
public class SetRandomPositionInCollider : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BoxCollider _collider;

    public void SetPosition()
    {
        transform.position = GetRandomPointInCollider();
    }

    private Vector3 GetRandomPointInCollider()
    {
        Vector3 extents = _collider.size / 2f;

        Vector3 point = new Vector3(
            Random.Range(-extents.x, extents.x),
            Random.Range(-extents.y, extents.y),
            Random.Range(-extents.z, extents.z)
        ) + _collider.center;

        return _collider.transform.TransformPoint(point);
    }
}
