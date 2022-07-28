using UnityEngine;

// Handles enabling/disabling mesh renderer and switching layer masks on wall fragments when triggered by players smasher/fixer object
public class WallFragment : MonoBehaviour
{
    private MeshRenderer _mesh;

    private string _smashableMask = "Smashable";
    private string _fixableMask = "Fixable";

    private string _smasherTag = "Smasher";
    private string _fixerTag = "Fixer";

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _smasherTag)
        {
            gameObject.layer = LayerMask.NameToLayer(_fixableMask);
            _mesh.enabled = false;
        }
        else if (other.tag == _fixerTag)
        {
            gameObject.layer = LayerMask.NameToLayer(_smashableMask);
            _mesh.enabled = true;
        }

    }

}
