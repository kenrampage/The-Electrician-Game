using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    private AnimationHelper curtainsAnimHelper;
    private AnimationHelper fadeAnimHelper;

    [SerializeField] private GameObject curtains;
    [SerializeField] private GameObject fadeCanvas;

    private void Awake()
    {
        curtainsAnimHelper = curtains.GetComponent<AnimationHelper>();
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
        curtainsAnimHelper.PlayAnimAtIndex(0);
    }

    public void CurtainsClose()
    {
        curtainsAnimHelper.PlayAnimAtIndex(1);
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
