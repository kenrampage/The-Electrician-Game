using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayAnimationManager : MonoBehaviour
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

    public void FadeCanvasOn()
    {
        _fadeCanvas.SetActive(true);
    }

    public void FadeCanvasOff()
    {
        _fadeCanvas.SetActive(false);
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
