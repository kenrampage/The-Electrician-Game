using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;

    // public InputAsset inputAsset;
    public InputActionAsset inputActions;
    private InputActionMap inputActionMap;

    public GameObject currentTarget;

    private InventoryManager inventoryManager;
    // public LayerMask layerMaskTarget;
    // public int layerMaskTargetIndex;
    // public LayerMask layerMaskSelected;

    private InputAction interactA;
    private InputAction interactB;

    public GameObject cursorObject;


    public void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        cam = Camera.main;
    }

    private void Start()
    {
        InputManager.Instance.onInteract.AddListener(Interact);
    }

    // Update is called once per frame
    void Update()
    {
        CastRay();
    }

    public void Interact()
    {
        if (currentTarget == null) return;
        if (currentTarget.CompareTag(inventoryManager.tagsList[inventoryManager.CurrentIndex]))
        {
            var interactable = currentTarget.GetComponent<IInteractable>();
            if (interactable == null) return;

            interactable.Interact();
        }
    }

    public void Cancel()
    {
        if (currentTarget == null) return;

        if (currentTarget.CompareTag(inventoryManager.tagsList[inventoryManager.CurrentIndex]))
        {
            var interactable = currentTarget.GetComponent<IInteractable>();
            if (interactable == null) return;

            interactable.Cancel();
        }

    }

    public void CastRay()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {

            currentTarget = hit.transform.gameObject;

            if (currentTarget.CompareTag(inventoryManager.tagsList[inventoryManager.CurrentIndex]))
            {
                cursorObject.transform.position = hit.point;
            }
            else
            {
                // currentTarget = null;
                cursorObject.transform.position = new Vector3(0, 0, 0);
            }

        }

    }

}

