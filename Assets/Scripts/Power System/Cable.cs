using UnityEngine;

// Primary class for handling cable interactions and directing changes in other cable classes
[RequireComponent(typeof(CableTransform)), RequireComponent(typeof(CableVisuals))]
public class Cable : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CableCollision _cableCollision;
    private CableTransform _cableTransform;
    private CableVisuals _cableVisuals;

    [Header("Audio")]
    [SerializeField] private FMODPlayOneShot _sfxCablePickup;
    [SerializeField] private FMODPlayOneShot _sfxCableDrop;
    [SerializeField] private FMODPlayOneShot _sfxCablePreview;
    [SerializeField] private FMODPlayOneShot _sfxCableInstallPower;
    [SerializeField] private FMODPlayOneShot _sfxCableInstall;

    [Header("Particles")]
    [SerializeField] private ParticleSystem _vfxCableInstallPower;

    private NodeManager _nodeManager;

    private Node _sourceNode;
    private Node _endNode;

    private bool _isColliding;
    private bool _isSelected;

    private void OnEnable()
    {
        _nodeManager = NodeManager.Instance;
        _cableVisuals = GetComponent<CableVisuals>();
        _cableTransform = GetComponent<CableTransform>();
        InputManager.Instance.OnCancelEvent.AddListener(HandleCancelInput);
    }

    #region Handle Cable state changes

    // Connect to source node and hold cable after interacting with node while not holding a cable
    public void ConnectToSourceNode(Node node)
    {
        SetSourceNode(node);
        _cableTransform.SetStartPosition(transform.position);
        _cableTransform.Edit();
        _cableCollision.SetPassthroughMask();

        // // Play Audio
        // _sfxCableInstall.PlayAttached(_sourceNode.gameObject);

        // // Play VFX
        // if (_sourceNode.CheckPowerStatus())
        // {
        //     PlayVFXAtPosition(_sourceNode.transform.position);
        // }

        // Play Audio and VFX
        if (_sourceNode.CheckPowerStatus())
        {
            _sfxCableInstallPower.PlayAttached(_sourceNode.gameObject);
            PlayVFXAtPosition(_sourceNode.transform.position);
        }
        else
        {
            _sfxCableInstall.PlayAttached(_sourceNode.gameObject);
        }

    }

    // Preview on end node while holding cable and hovering over a node
    public void PreviewAtEndNodeOn(Node node)
    {
        _cableTransform.Preview(node.transform.position);
        _cableVisuals.PreviewOn();

        // Play Audio
        _sfxCablePreview.PlayAttached(node.gameObject);
    }

    // Stop previewing when holding cable and no longer hovering over end node
    public void PreviewAtEndNodeOff(Node node)
    {
        // Play Audio
        if (node != _sourceNode)
        {
            _sfxCablePreview.PlayAttached(node.gameObject);
        }
        _cableTransform.Edit();

    }

    // Connect to end node after interacting with a node while holding the cable
    public void ConnectToEndNode(Node node)
    {
        _cableTransform.SetEndPosition(node.transform.position);

        SetEndNode(node);
        AddEndNodeToSourceNode();
        AddSourceNodeToEndNode();

        _nodeManager.AddConnectedNode(_sourceNode);
        _nodeManager.AddConnectedNode(_endNode);

        _cableVisuals.DefaultOn();
        _cableTransform.Install();

        InventoryManager.Instance.DropCable();

        _cableCollision.SetSelectableMask();

        // Play Audio and VFX
        if (_sourceNode.CheckPowerStatus() || _endNode.CheckPowerStatus())
        {
            _sfxCableInstallPower.PlayAttached(_endNode.gameObject);
            PlayVFXAtPosition(_endNode.transform.position);
        }
        else
        {
            _sfxCableInstall.PlayAttached(_endNode.gameObject);
        }

    }

    // Disconnect from end node and hold cable after interacting with the body of an installed cabled
    public void DisconnectFromEndNode()
    {
        RemoveEndNodeFromSourceNode();
        RemoveSourceNodeFromEndNode();

        _nodeManager.RemoveConnectedNode(_sourceNode);
        _nodeManager.RemoveConnectedNode(_endNode);

        _cableTransform.Edit();
        InventoryManager.Instance.PickupCable(this.gameObject);

        ClearEndNode();

        _cableCollision.SetPassthroughMask();

        // Play audio
        _sfxCablePickup.Play();
    }

    // Destroy cable while holding cable and cancelling (right click)
    public void DestroyCable()
    {
        // Play Audio
        _sfxCableDrop.Play();

        InventoryManager.Instance.DestroyHeldCable();
    }
    #endregion


    #region Node Connection Methods
    private void AddEndNodeToSourceNode()
    {
        if (_endNode != null)
        {
            _sourceNode.AddConnectedNode(_endNode);
        }
    }

    private void AddSourceNodeToEndNode()
    {
        if (_endNode != null)
        {
            _endNode.AddConnectedNode(_sourceNode);
        }
    }

    private void RemoveEndNodeFromSourceNode()
    {
        if (_endNode != null)
        {
            _sourceNode.RemoveConnectedNode(_endNode);
        }
    }

    private void RemoveSourceNodeFromEndNode()
    {
        if (_endNode != null)
        {
            _endNode.RemoveConnectedNode(_sourceNode);
        }
    }

    private void SetSourceNode(Node node)
    {
        _sourceNode = node;
    }
    private void SetEndNode(Node node)
    {
        _endNode = node;
    }

    private void ClearSourceNode()
    {
        _sourceNode = null;
    }

    private void ClearEndNode()
    {
        _endNode = null;
    }

    public Node GetSourceNode()
    {
        return _sourceNode.GetComponent<Node>();
    }

    public Node GetEndNode()
    {
        return _endNode.GetComponent<Node>();
    }

    public bool CheckIfSourceNode(Node node)
    {
        if (node == _sourceNode)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckIfEndNode(Node node)
    {
        if (node == _endNode)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    #endregion


    #region State get/set methods
    public void CollisionOn()
    {
        _isColliding = true;
        _cableVisuals.CollisionOn();
    }

    public void CollisionOff()
    {
        _isColliding = false;
        _cableVisuals.PreviewOn();
    }

    public bool CheckIfColliding()
    {
        return _isColliding;
    }

    public void SelectedOn()
    {
        if (!InventoryManager.Instance.CheckIfHoldingCable())
        {
            _isSelected = true;
            _cableVisuals.HighlightOn();
        }
    }

    public void SelectedOff()
    {
        if (!InventoryManager.Instance.CheckIfHoldingCable())
        {
            _isSelected = false;
            _cableVisuals.DefaultOn();
        }
    }

    public bool SelectedCheck()
    {
        return _isSelected;
    }
    #endregion


    #region Input Handling
    public void HandleInteractInput()
    {
        if (!InventoryManager.Instance.CheckIfHoldingCable())
        {
            DisconnectFromEndNode();
        }
    }

    public void HandleCancelInput()
    {
        if (InventoryManager.Instance.CheckIfCableMatches(this.gameObject))
        {
            DestroyCable();
        }
    }
    #endregion

    private void PlayVFXAtPosition(Vector3 pos)
    {
        _vfxCableInstallPower.transform.position = pos;
        _vfxCableInstallPower.Play();
    }

}
