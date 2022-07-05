using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationHelper : MonoBehaviour
{
    private Animation anim;
    [SerializeField] private AnimationClip[] clips;

    private void Awake()
    {
        anim = GetComponent<Animation>();
        
    }

    private void AddClipsToAnimationComponent()
    {
        foreach (var clip in clips)
        {
            anim.AddClip(clip, clip.name);
        }
    }

    public void PlayAnimAtIndex(int i)
    {
        anim.Play(clips[i].name);
    }

    [ContextMenu("Test Animation 1")]
    public void TestAnimation1()
    {
        PlayAnimAtIndex(0);
    }

    [ContextMenu("Test Animation 2")]
    public void TestAnimation2()
    {
        PlayAnimAtIndex(1);
    }
}
