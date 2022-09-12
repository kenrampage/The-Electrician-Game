using UnityEngine;

// Controls the animation for curtains overlay
public class Anim_Curtains : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private FMODPlayOneShot _sfxCurtainsOpen;

    [Header("Settings")]
    [SerializeField] private bool _isOpenAtStart;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        if (_isOpenAtStart)
        {
            SetCurtainsOpen();
        }
        else
        {
            SetCurtainsClosed();
        }
    }

    [ContextMenu("Open Curtains")]
    public void CurtainsOpen()
    {
        SetCurtainsOpen();
        _sfxCurtainsOpen.Play();
    }

    [ContextMenu("Close Curtains")]
    public void CurtainsClose()
    {
        SetCurtainsClosed();
        _sfxCurtainsOpen.Play();
    }

    private void SetCurtainsClosed()
    {
        _anim.SetBool("isOpen", false);
    }

    private void SetCurtainsOpen()
    {
        _anim.SetBool("isOpen", true);
    }
}
