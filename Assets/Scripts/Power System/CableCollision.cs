using UnityEngine;

// Detects trigger collision with walls and cursor
public class CableCollision : MonoBehaviour, IInteractable
{
    [Header("References")]
    [SerializeField] private Cable _cable;

    private string _wallTag = "Wall";
    private string _cursorTag = "Cursor";

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == _wallTag)
        {
            _cable.CollisionOn();
        }
        else if (other.gameObject.tag == _cursorTag)
        {
            _cable.SelectedOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == _wallTag)
        {
            _cable.CollisionOff();
        }
        else if (other.gameObject.tag == _cursorTag)
        {
            _cable.SelectedOff();
        }
    }

    public void Interact()
    {
        _cable.HandleInteractInput();
    }

    public void Cancel()
    {

    }
}
