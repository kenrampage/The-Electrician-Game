using UnityEngine;
using TMPro;

public class ToggleTextGlow : MonoBehaviour
{
    private Material material;
    [SerializeField] private bool isGlowOn;

    private void OnEnable()
    {
        material = GetComponent<TextMeshProUGUI>().fontMaterial;
        CheckTextGlowStatus();

    }

    public void CheckTextGlowStatus()
    {
        isGlowOn = material.IsKeywordEnabled("GLOW_ON");
    }


    [ContextMenu("Turn Glow On")]
    public void TurnGlowOn()
    {
        material.EnableKeyword("GLOW_ON");
        isGlowOn = true;
    }

    [ContextMenu("Turn Glow Off")]
    public void TurnGlowOff()
    {
        material.DisableKeyword("GLOW_ON");
        isGlowOn = false;
    }

    [ContextMenu("Toggle Glow")]
    public void ToggleGlow()
    {
        if (isGlowOn)
        {
            TurnGlowOff();
        }
        else
        {
            TurnGlowOn();
        }

    }
}
