using UnityEngine;

// Helper class for manually triggering animations in legacy animation component
[RequireComponent(typeof(Animation))]
public class AnimationHelper : MonoBehaviour
{
    private Animation _anim;

    [Header("Animation Clips")]
    [SerializeField] private AnimationClip[] _clips;

    private void Awake()
    {
        _anim = GetComponent<Animation>();
        AddClipsToAnimationComponent();
    }

    private void AddClipsToAnimationComponent()
    {
        if (_anim.GetClipCount() == 0)
        {
            foreach (var clip in _clips)
            {
                _anim.AddClip(clip, clip.name);
            }
        }
    }

    public void PlayAnimAtIndex(int i)
    {
        _anim.Play(_clips[i].name);
    }

}
