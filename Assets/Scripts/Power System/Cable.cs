using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Primary class for handling cable interactions and directing changes in other cable classes
public class Cable : MonoBehaviour
{
    private CableTransform _cableTransform;
    private CableMaterials _cableMaterials;

    private Node _sourceNode;
    private Node _endNode;

    [SerializeField]
    private bool _isColliding;
    private bool _isSelected;

    private void OnEnable()
    {
        _cableMaterials = GetComponent<CableMaterials>();
        _cableTransform = GetComponent<CableTransform>();
        InputManager.Instance.onCancel.AddListener(HandleCancelInput);
    }

    #region Handle Cable state changes

    // Connect to source node and hold cable after interacting with node while not holding a cable
    public void ConnectToSourceNode(Node node)
    {
        SetSourceNode(node);
        _cableTransform.SetStartPosition(transform.position);
        _cableTransform.Edit();
    }

    // Preview on end node while holding cable and hovering over a node
    public void PreviewAtEndNodeOn(Node node)
    {
        _cableTransform.Preview(node.transform.position);
        _cableMaterials.PreviewOn();
    }

    // Stop previewing when holding cable and no longer hovering over end node
    public void PreviewAtEndNodeOff(Node node)
    {
        _cableTransform.Edit();

    }

    // Connect to end node after interacting with a node while holding the cable
    public void ConnectToEndNode(Node node)
    {
        _cableTransform.SetEndPosition(node.transform.position);

        SetEndNode(node);
        AddEndNodeToSourceNode();
        AddSourceNodeToEndNode();

        _cableMaterials.DefaultOn();
        _cableTransform.Install();

        InventoryManager.Instance.DropCable();
    }

    // Disconnect from end node and hold cable after interacting with the body of an installed cabled
    public void DisconnectFromEndNode()
    {
        RemoveEndNodeFromSourceNode();
        RemoveSourceNodeFromEndNode();

        _cableTransform.Edit();
        InventoryManager.Instance.PickupCable(this.gameObject);

        ClearEndNode();
    }

    // Destroy cable while holding cable and cancelling (right click)
    public void DestroyCable()
    {
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
        _cableMaterials.CollisionOn();
    }

    public void CollisionOff()
    {
        _isColliding = false;
        _cableMaterials.PreviewOn();
    }

    public bool CheckIfColliding()
    {
        return _isColliding;
    }

    public void SelectedOn()
    {
        if (!InventoryManager.Instance._isHoldingCable)
        {
            _isSelected = true;
            _cableMaterials.HighlightOn();
        }
    }

    public void SelectedOff()
    {
        if (!InventoryManager.Instance._isHoldingCable)
        {
            _isSelected = false;
            _cableMaterials.DefaultOn();
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
        if (!InventoryManager.Instance._isHoldingCable)
        {
            DisconnectFromEndNode();
        }
    }

    public void HandleCancelInput()
    {
        if (InventoryManager.Instance.heldCable == this.gameObject)
        {
            DestroyCable();
        }
    }
    #endregion

}
