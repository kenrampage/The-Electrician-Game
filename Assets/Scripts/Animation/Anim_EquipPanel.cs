using UnityEngine;

// Controls animation for game equipment panel
public class Anim_EquipPanel : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator _anim;

    [Header("Settings")]
    [SerializeField] private bool _isInAtStart;

    private void Awake()
    {
        if (_isInAtStart)
        {
            EquipPanelIn();
        }
        else
        {
            EquipPanelOut();
        }
    }

    public void EquipPanelIn()
    {
        _anim.SetBool("isIn", true);
    }

    public void EquipPanelOut()
    {
        _anim.SetBool("isIn", false);
    }
}
