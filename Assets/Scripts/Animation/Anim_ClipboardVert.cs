using UnityEngine;

// Controls animation for vertical clipboard UI objects
public class Anim_ClipboardVert : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator _anim;

    [Header("Settings")]
    [SerializeField] private bool _isInAtStart;

    private void Awake()
    {
        if (_isInAtStart)
        {
            ClipboardIn();
        }
        else
        {
            ClipboardOut();
        }
    }

    public void ClipboardIn()
    {
        _anim.SetBool("isIn", true);
    }

    public void ClipboardOut()
    {
        _anim.SetBool("isIn", false);
    }
}
