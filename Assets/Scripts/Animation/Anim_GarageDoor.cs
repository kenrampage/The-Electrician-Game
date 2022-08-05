using UnityEngine;

// Controls animation for Garage Door
public class Anim_GarageDoor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator _anim;

    [Header("Settings")]
    [SerializeField] private bool _isOpenAtStart;

    private void Awake()
    {
        if (_isOpenAtStart)
        {
            GarageOpen();
        }
        else
        {
            GarageClose();
        }
    }

    [ContextMenu("Open")]
    public void GarageOpen()
    {
        _anim.SetBool("IsOpen", true);
    }

    [ContextMenu("Close")]
    public void GarageClose()
    {
        _anim.SetBool("IsOpen", false);
    }
}
