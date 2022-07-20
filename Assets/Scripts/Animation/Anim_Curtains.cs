using UnityEngine;

// Controls the animation for curtains overlay
public class Anim_Curtains : MonoBehaviour
{
    private Animator _anim;

    [Header("Settings")]
    [SerializeField] private bool _isOpenAtStart;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        if (_isOpenAtStart)
        {
            CurtainsOpen();
        }
        else
        {
            CurtainsClose();
        }
    }

    [ContextMenu("Open Curtains")]
    public void CurtainsOpen()
    {
        _anim.SetBool("isOpen", true);
    }

    [ContextMenu("Close Curtains")]
    public void CurtainsClose()
    {
        _anim.SetBool("isOpen", false);
    }
}
