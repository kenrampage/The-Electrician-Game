using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueWalkieEffect_Basic : DialogueWalkieEffect
{
    public override IEnumerator EffectCoroutine()
    {
        while(_effectOn)
        {
            DisableAllSpriteObjects();

            int newIndex = CalcRandomSpriteIndex();
            _walkie.transform.localScale = _walkieOriginalScale * CalcRandomScale();

            _spriteObjects[newIndex].SetActive(true);

            yield return new WaitForSeconds(CalcRandomDelay());
        }
        
    }
}
