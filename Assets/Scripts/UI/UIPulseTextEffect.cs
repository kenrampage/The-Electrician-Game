using UnityEngine;
using TMPro;
using DG.Tweening;

public class UIPulseTextEffect : MonoBehaviour
{
    private TextMeshProUGUI _text;

    [Header("Settings")]
    [SerializeField] private bool _pulseEffectOn;
    [SerializeField] private bool _fadeInAtStart;
    [SerializeField] private float _effectLength;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();

        if (_pulseEffectOn)
        {
            if (_fadeInAtStart)
            {
                _text.DOFade(0, _effectLength).SetLoops(-1, LoopType.Yoyo).From();
            }
            else
            {
                _text.DOFade(0, _effectLength).SetLoops(-1, LoopType.Yoyo);
            }
        }
    }

}
