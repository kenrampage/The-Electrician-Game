using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    private Anim_Curtains anim_Curtains;
    private AnimationHelper fadeAnimHelper;

    [SerializeField] private GameObject curtains;
    [SerializeField] private GameObject fadeCanvas;

    private void Awake()
    {
        anim_Curtains = curtains.GetComponent<Anim_Curtains>();
        fadeAnimHelper = fadeCanvas.GetComponent<AnimationHelper>();
    }

    public void CurtainsOn()
    {
        curtains.SetActive(true);
    }

    public void CurtainsOff()
    {
        curtains.SetActive(false);
    }

    public void CurtainsOpen()
    {
        anim_Curtains.CurtainsOpen();
    }

    public void CurtainsClose()
    {
        anim_Curtains.CurtainsClose();
    }

    public void FadeIn()
    {
        fadeAnimHelper.PlayAnimAtIndex(0);
    }

    public void FadeOut()
    {
        fadeAnimHelper.PlayAnimAtIndex(1);
    }
}
