using UnityEngine;

public class Anim_SplashScreen : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animation[] _animations;

    public void StartAnimations()
    {
        foreach (var anim in _animations)
        {
            anim.Play();
        }
    }
}
