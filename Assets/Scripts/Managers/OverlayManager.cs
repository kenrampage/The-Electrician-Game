using UnityEngine;

// For easier management of overlay objects used for transitioning between scenes and menus
public class OverlayManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _curtains;
    [SerializeField] private GameObject _fadeCanvas;

    private Anim_Curtains _anim_Curtains;
    private AnimationHelper _fadeAnimHelper;

    private void Awake()
    {
        _anim_Curtains = _curtains.GetComponent<Anim_Curtains>();
        _fadeAnimHelper = _fadeCanvas.GetComponent<AnimationHelper>();
    }

    public void CurtainsOn()
    {
        _curtains.SetActive(true);
    }

    public void CurtainsOff()
    {
        _curtains.SetActive(false);
    }

    public void CurtainsOpen()
    {
        _anim_Curtains.CurtainsOpen();
    }

    public void CurtainsClose()
    {
        _anim_Curtains.CurtainsClose();
    }

    public void FadeIn()
    {
        _fadeAnimHelper.PlayAnimAtIndex(0);
    }

    public void FadeOut()
    {
        _fadeAnimHelper.PlayAnimAtIndex(1);
    }
}
