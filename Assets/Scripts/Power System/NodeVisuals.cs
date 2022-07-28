using UnityEngine;

// Handles visual effects of nodes
public class NodeVisuals : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _powerConnectedIndicator;
    [SerializeField] private GameObject _powerDisconnectedIndicator;
    [SerializeField] private MeshRenderer[] _highlightMeshes;

    #region Effects On/off functions
    public void HighlightOn()
    {
        foreach (var mesh in _highlightMeshes)
        {
            mesh.material.EnableKeyword("_EMISSION");
        }
    }

    public void HighlightOff()
    {
        foreach (var mesh in _highlightMeshes)
        {
            mesh.material.DisableKeyword("_EMISSION");
        }
    }

    public void PowerOn()
    {
        _powerConnectedIndicator.SetActive(true);
        _powerDisconnectedIndicator.SetActive(false);
    }

    public void PowerOff()
    {
        _powerConnectedIndicator.SetActive(false);
        _powerDisconnectedIndicator.SetActive(true);
    }
    #endregion

}
