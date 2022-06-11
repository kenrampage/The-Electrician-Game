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
    public LayerMask layerMaskTarget;
    public LayerMask layerMaskSelected;

    private InputAction interactA;
    private InputAction interactB;


    public void Awake()
    {

        inventoryManager = FindObjectOfType<InventoryManager>();

        cam = Camera.main;

        inputActionMap = inputActions.FindActionMap("Player");
        // inputAsset = new InputAsset();

        interactA = inputActionMap.FindAction("Interact_1");
        interactB = inputActionMap.FindAction("Interact_2");

    }

    private void OnEnable()
    {
        interactA.performed += InteractA;
        interactB.performed += InteractB;
        // inputAsset.Player.Enable();
        interactA.Enable();
        interactB.Enable();
    }

    private void OnDisable()
    {
        interactA.performed -= InteractA;
        interactB.performed -= InteractB;
        interactA.Disable();
        interactB.Disable();
        // inputAsset.Player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        GetLayerMaskTarget();
        CastRay();
    }

    public void InteractA(InputAction.CallbackContext obj)
    {
        var interactable = currentTarget.GetComponent<IInteractable>();
        if (interactable == null) return;

        if(currentTarget.layer == inventoryManager.layerMasksList[inventoryManager.currentIndex])
        {
            interactable.InteractA();
        }

        print("target layer " + inventoryManager.layerMasksList[inventoryManager.currentIndex]);
        print("selected layer " + layerMaskSelected.value);
        

    }

    public void InteractB(InputAction.CallbackContext obj)
    {
        var interactable = currentTarget.GetComponent<IInteractable>();
        if (interactable == null) return;

        if(layerMaskSelected == layerMaskTarget)
        {
            interactable.InteractB();
        }
        
    }

    public void CastRay()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);


        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            currentTarget = hit.transform.gameObject;
            layerMaskSelected = currentTarget.layer;
        }
        else
        {
            currentTarget = null;
        }
    }

    public void GetLayerMaskTarget()
    {
        layerMaskTarget = inventoryManager.layerMasksList[inventoryManager.currentIndex];
    }
}

