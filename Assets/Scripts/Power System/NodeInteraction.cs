using UnityEngine;

// Handles node interaction and trigger enter/exit behaviour
public class NodeInteraction : MonoBehaviour, IInteractable
{
    private InventoryManager _inventoryManager;
    private Node _node;

    [SerializeField]
    private GameObject _cablePrefab;

    [SerializeField]
    private int _wiringItemIndex;

    private void Awake()
    {
        _inventoryManager = InventoryManager.Instance;
        _node = GetComponent<Node>();
    }

    #region Bool Check Functions
    private bool CheckIfInstallable(Cable cable)
    {
        if (_node.CheckIfConnectedToNode(cable.GetSourceNode()) || cable.CheckIfSourceNode(_node) || cable.CheckIfColliding())
        {
            return false;
        }
        else if (!_node.CheckIfConnectedToNode(cable.GetSourceNode()) && !cable.CheckIfSourceNode(_node) && !cable.CheckIfColliding())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckIfWiringItemEquipped()
    {
        if (_inventoryManager.CheckIfMatchCurrentIndex(_wiringItemIndex))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region IInteractable Functions
    public void Interact()
    {
        // Checks if wiring item is equipped and not holding cable
        if (CheckIfWiringItemEquipped() && !_inventoryManager.CheckIfHoldingCable())
        {
            //creates cable
            var newCable = Instantiate(_cablePrefab, transform.position, transform.rotation);
            var cable = newCable.GetComponent<Cable>();

            //sets this cable as currently held cable
            _inventoryManager.PickupCable(newCable);
            cable.ConnectToSourceNode(_node);

        }
        // Checks if wiring item is equipped and is holding cable
        else if (CheckIfWiringItemEquipped() && _inventoryManager.CheckIfHoldingCable())
        {
            var cable = _inventoryManager.heldCable.GetComponent<Cable>();

            // Checks if this node is already connected to the cable source node, if this node is the cable's source node, and if the cable is colliding with walls
            if (!CheckIfInstallable(cable))
            {
                return;
            }
            else if (CheckIfInstallable(cable))
            {
                cable.ConnectToEndNode(_node);
                // _node.NodeVisuals.HighlightOff();
            }

        }
    }

    public void Cancel()
    {
        // Implemented to appease IInteractable interface
    }
    #endregion

    #region Trigger Enter/Exit functions
    private void OnTriggerEnter(Collider other)
    {
        if (CheckIfWiringItemEquipped() && !_inventoryManager.CheckIfHoldingCable() && other.tag == "Cursor")
        {
            _node.NodeVisuals.HighlightOn();

        }
        else if (CheckIfWiringItemEquipped() && _inventoryManager.CheckIfHoldingCable() && other.tag == "Cursor")
        {
            _node.NodeVisuals.HighlightOn();
            Cable cable = _inventoryManager.heldCable.GetComponent<Cable>();

            if (!_node.CheckIfConnectedToNode(cable.GetSourceNode()) && !cable.CheckIfSourceNode(_node))
            {
                cable.PreviewAtEndNodeOn(_node);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckIfWiringItemEquipped() && !_inventoryManager.CheckIfHoldingCable() && other.tag == "Cursor")
        {
            _node.NodeVisuals.HighlightOff();

        }
        else if (CheckIfWiringItemEquipped() && _inventoryManager.CheckIfHoldingCable() && other.tag == "Cursor")
        {
            _node.NodeVisuals.HighlightOff();

            var cable = _inventoryManager.heldCable.GetComponent<Cable>();

            cable.PreviewAtEndNodeOff(_node);
        }
    }
    #endregion

}
