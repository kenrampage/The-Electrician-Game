using UnityEngine;

// Controls animation for Garage Door
public class Anim_GarageDoor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator _anim;

    [Header("Settings")]
    [SerializeField] private bool _isOpenAtStart;

    [Header("Audio")]
    [SerializeField] private FMODPlayOneShot _sfxGarageOpen;

    private void Awake()
    {
        if (_isOpenAtStart)
        {
            SetGarageOpen();
        }
        else
        {
            SetGarageClosed();
        }
    }

    [ContextMenu("Open")]
    public void GarageOpen()
    {
        SetGarageOpen();
        _sfxGarageOpen.Play();
    }

    [ContextMenu("Close")]
    public void GarageClose()
    {
        SetGarageClosed();
        _sfxGarageOpen.Play();
    }

    private void SetGarageOpen()
    {
        _anim.SetBool("IsOpen", true);
    }

    private void SetGarageClosed()
    {
        _anim.SetBool("IsOpen", false);
    }
}
