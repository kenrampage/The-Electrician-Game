using UnityEngine;

// Controls animation for vertical clipboard UI objects
public class Anim_ClipboardVert : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator _anim;

    [Header("Settings")]
    [SerializeField] private bool _isInAtStart;

    [Header("Audio")]
    [SerializeField] private FMODPlayOneShot _sfxClipboardIn;
    [SerializeField] private FMODPlayOneShot _sfxClipboardOut;

    private void Awake()
    {
        if (_isInAtStart)
        {
            SetClipboardIn();
        }
        else
        {
            SetClipboardOut();
        }
    }

    public void ClipboardIn()
    {
        SetClipboardIn();
        _sfxClipboardIn.Play();
    }

    public void ClipboardOut()
    {
        SetClipboardOut();
        _sfxClipboardOut.Play();
    }

    private void SetClipboardIn()
    {
        _anim.SetBool("isIn", true);
    }

    private void SetClipboardOut()
    {
        _anim.SetBool("isIn", false);
    }
}
