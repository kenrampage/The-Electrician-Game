using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    [SerializeField] private AnimationHelper curtainsAnimHelper;
    [SerializeField] private AnimationHelper fadeAnimHelper;

    public void OpenCurtains()
    {
        curtainsAnimHelper.PlayAnimAtIndex(0);
    }

    public void CloseCurtains()
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
