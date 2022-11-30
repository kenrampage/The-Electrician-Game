using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages references to objects for each type of Dialogue Walkie Effect and passes start/end method calls
public class DialogueWalkieEffectManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _walkieObject;
    [SerializeField] private DialogueWalkieEffect _basicEffect;
    [SerializeField] private DialogueWalkieEffect _angryEffect;

    private DialogueWalkieEffect _currentEffect;

    public void SetEffectType(WalkieEffectType effectType)
    {
        switch (effectType)
        {
            case WalkieEffectType.BASIC:
                _currentEffect = _basicEffect;
                break;

            case WalkieEffectType.ANGRY:
                _currentEffect = _angryEffect;
                break;

            default:
                break;
        }
    }

    public void StartEffect()
    {
        _currentEffect.SetWalkieObject(_walkieObject);
        _currentEffect.StartEffect();
    }

    public void EndEffect()
    {
        _currentEffect.EndEffect();
    }

}
