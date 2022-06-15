using UnityEngine;

public class PlayerHoldPosition : MonoBehaviour
{

    public static Vector3 position;

    private void Update()
    {
        position = transform.position;
    }
}
