using UnityEngine;

// Easier reference for current position where the player holds cable
public class PlayerHoldPosition : MonoBehaviour
{
    private static Vector3 _position;
    public static Vector3 Position
    {
        get { return _position; }
    }

    private void Update()
    {
        _position = transform.position;
    }
}
