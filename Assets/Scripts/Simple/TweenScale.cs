using UnityEngine;
using DG.Tweening;

// Handles scale tweening of this object
public class TweenScale : MonoBehaviour
{
    private Vector3 _initialScale;

    [Header("Settings")]
    [SerializeField] private float _scaleMultiplier;
    [SerializeField] private float _length;
    [SerializeField] private bool _scaleUp;

    void Start()
    {
        _initialScale = transform.localScale;
    }

    private void ScaleUp()
    {
        transform.DOScale(_initialScale * _scaleMultiplier, _length)
        .OnComplete(() =>
        {
            transform.localScale = _initialScale;
        });
    }

    private void ScaleDown()
    {
        transform.localScale = _initialScale * _scaleMultiplier;
        transform.DOScale(_initialScale, _length).Restart();
    }

    public void Scale()
    {
        if (_scaleUp)
        {
            ScaleUp();
        }
        else
        {
            ScaleDown();
        }
    }
}
