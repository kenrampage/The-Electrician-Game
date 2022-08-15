using UnityEngine;

// Handles swapping materials of cable
public class CableVisuals : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MeshRenderer _cableMesh;

    [Header("Materials")]
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _previewMaterial;
    [SerializeField] private Material _collisionMaterial;
    [SerializeField] private Material _highlightMaterial;


    public void PreviewOn()
    {
        _cableMesh.material = _previewMaterial;
    }

    public void HighlightOn()
    {
        _cableMesh.material = _highlightMaterial;
    }

    public void DefaultOn()
    {
        _cableMesh.material = _defaultMaterial;
    }

    public void CollisionOn()
    {
        _cableMesh.material = _collisionMaterial;
    }
}
