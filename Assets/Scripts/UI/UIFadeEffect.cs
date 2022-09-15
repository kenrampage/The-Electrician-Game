using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIFadeEffect : MonoBehaviour
{
    private Image _panel;

    [Header("Settings")]
    [SerializeField] private float _fadeLength;
    [SerializeField] private bool _fadeInAtStart;

    private void Awake()
    {
        _panel = GetComponent<Image>();

    }

    private void OnEnable()
    {
        if (_fadeInAtStart)
        {
            FadeIn();
        }
    }

    [ContextMenu("Fade In")]
    public void FadeIn()
    {
        _panel.DOFade(0, _fadeLength).From(1);
    }

    [ContextMenu("Fade Out")]
    public void FadeOut()
    {
        _panel.DOFade(1, _fadeLength).From(0);
    }
}
