using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bass class for different types of visual effects for the walkie talkie included in the dialogue box
// Receives input from DialogueWalkieEffectManager script
public abstract class DialogueWalkieEffect : MonoBehaviour
{
    protected bool _effectOn;
    protected Vector3 _walkieOriginalScale;

    [Header("References")]
    protected GameObject _walkie;
    protected DialogueWalkieEffectManager _walkieEffectManager;

    [Header("Visual Objects")]
    [SerializeField] protected GameObject[] _spriteObjects;

    [Header("Settings")]
    [SerializeField] protected float _minDelay;
    [SerializeField] protected float _maxDelay;
    [SerializeField] protected float _minScaleModifier;
    [SerializeField] protected float _maxScaleModifier;

    
    public void StartEffect()
    {
        _effectOn = true;
        StartCoroutine(EffectCoroutine());
    }

    public void EndEffect()
    {
        _effectOn = false;
        StopCoroutine(EffectCoroutine());
        DisableAllSpriteObjects();
    }

    public void SetWalkieObject(GameObject obj)
    {
        _walkie = obj;
        _walkieOriginalScale = _walkie.transform.localScale;
    }

    protected int CalcRandomSpriteIndex()
    {
        int i = Random.Range(0, _spriteObjects.Length);
        return i;
    }

    protected float CalcRandomDelay()
    {
        return Random.Range(_minDelay, _maxDelay);
    }

    protected float CalcRandomScale()
    {
        return Random.Range(_minScaleModifier, _maxScaleModifier);
    }

    protected void DisableAllSpriteObjects()
    {
        foreach (GameObject obj in _spriteObjects)
        {
            obj.SetActive(false);
        }
    }

    abstract public IEnumerator EffectCoroutine();

}
