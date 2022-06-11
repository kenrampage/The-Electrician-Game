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

    public GameObject raycastIndicator;


    public void Awake()
    {

        inventoryManager = FindObjectOfType<InventoryManager>();

        cam = Camera.main;

        inputActionMap = inputActions.FindActionMap("Player");

        interactA = inputActionMap.FindAction("Interact_1");
        interactB = inputActionMap.FindAction("Interact_2");

    }

    private void OnEnable()
    {
        interactA.performed += InteractA;
        interactB.performed += InteractB;
        interactA.Enable();
        interactB.Enable();
    }

    private void OnDisable()
    {
        interactA.performed -= InteractA;
        interactB.performed -= InteractB;
        interactA.Disable();
        interactB.Disable();

    }

    // Update is called once per frame
    void Update()
    {
        CastRay();
    }

    public void InteractA(InputAction.CallbackContext obj)
    {
        if (currentTarget == null) return;
        if (currentTarget.CompareTag(inventoryManager.tagsList[inventoryManager.currentIndex]))
        {
            var interactable = currentTarget.GetComponent<IInteractable>();
            if (interactable == null) return;

            interactable.InteractA();
        }
    }

    public void InteractB(InputAction.CallbackContext obj)
    {
        if (currentTarget == null) return;

        if (currentTarget.CompareTag(inventoryManager.tagsList[inventoryManager.currentIndex]))
        {
            var interactable = currentTarget.GetComponent<IInteractable>();
            if (interactable == null) return;

            interactable.InteractB();
        }

    }

    public void CastRay()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {

            currentTarget = hit.transform.gameObject;

            if (currentTarget.CompareTag(inventoryManager.tagsList[inventoryManager.currentIndex]))
            {
                raycastIndicator.transform.position = hit.point;
            }
            else
            {
                // currentTarget = null;
                raycastIndicator.transform.position = new Vector3(0, 0, 0);
            }

        }

    }

}

