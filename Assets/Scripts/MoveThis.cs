using UnityEngine;

public class MoveThis : MonoBehaviour
{
    [SerializeField] private Vector3 moveSpeed;
    [SerializeField] private bool isMovementOn;

    private void Update()
    {
        if(isMovementOn)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(moveSpeed * Time.deltaTime, Space.World);
    }

    public void TurnMovementOn()
    {
        isMovementOn = true;
    }

    public void TurnMovementOff()
    {
        isMovementOn = false;
    }

}
