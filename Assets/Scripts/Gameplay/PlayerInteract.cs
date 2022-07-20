using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;

    // public InputAsset inputAsset;
    // public InputActionAsset inputActions;
    // private InputActionMap inputActionMap;

    public GameObject currentTarget;


    private InventoryManager inventoryManager;
    // public LayerMask layerMaskTarget;
    // public int layerMaskTargetIndex;
    // public LayerMask layerMaskSelected;

    // private InputAction interactA;
    // private InputAction interactB;

    public GameObject cursorObject;
    // public SmashAndFix smashAndFix;
    public bool onTarget;


    public void Awake()
    {
        // smasher = GetComponent<Smasher>();
        inventoryManager = FindObjectOfType<InventoryManager>();
        cam = Camera.main;
    }

    private void Start()
    {
        InputManager.Instance.onInteract.AddListener(Interact);
        // InputManager.Instance.onInteractRelease.AddListener(InteractRelease);
        // InputManager.Instance.onCancel.AddListener(Cancel);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CastRay();
    }

    public void Interact()
    {
        if (inventoryManager.CurrentIndex != 1 && inventoryManager.CurrentIndex != 2)
        {
            if (currentTarget == null) return;

            var interactable = currentTarget.GetComponent<IInteractable>();
            if (interactable == null) return;

            interactable.Interact();
            // if (currentTarget.CompareTag(inventoryManager.tagsList[inventoryManager.CurrentIndex]))
            // {
            //     var interactable = currentTarget.GetComponent<IInteractable>();
            //     if (interactable == null) return;

            //     interactable.Interact();
            // }
        }

    }


    public void CastRay()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);


        if (Physics.Raycast(ray, out RaycastHit hit, 5f, inventoryManager.layerMasksList[inventoryManager.CurrentIndex]))
        {
            currentTarget = hit.transform.gameObject;
            onTarget = true;
            cursorObject.SetActive(true);
            
            cursorObject.transform.position = hit.point;
            inventoryManager.TurnReticleOff();

        }
        else
        {
            inventoryManager.TurnReticleOn();
            currentTarget = null;
            onTarget = false;
            cursorObject.transform.localPosition = new Vector3(0, 0, -3);
        }

    }

}

