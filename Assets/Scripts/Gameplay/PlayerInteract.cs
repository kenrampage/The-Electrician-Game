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
    public GameObject smasherObject;
    public GameObject smasherDefaultPosition;
    public float smashDuration;
    public bool ableToSmash = true;


    public bool onTarget;


    public void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        cam = Camera.main;
    }

    private void Start()
    {
        InputManager.Instance.onInteract.AddListener(Interact);
        InputManager.Instance.onInteractRelease.AddListener(InteractRelease);
    }

    // Update is called once per frame
    void Update()
    {
        CastRay();
    }

    public void Interact()
    {
        if (inventoryManager.CurrentIndex != 8)
        {
            if (currentTarget == null) return;
            if (currentTarget.CompareTag(inventoryManager.tagsList[inventoryManager.CurrentIndex]))
            {
                var interactable = currentTarget.GetComponent<IInteractable>();
                if (interactable == null) return;

                interactable.Interact();
            }
        }

    }

    public void InteractRelease()
    {
        if (inventoryManager.CurrentIndex != 8)
        {

        }
        else if (onTarget)
        {
            StartCoroutine(Smash());
        }
    }


    public IEnumerator Smash()
    {
        if (ableToSmash)
        {
            ableToSmash = false;
            smasherObject.SetActive(true);
            smasherObject.transform.position = cursorObject.transform.position;
            yield return new WaitForSecondsRealtime(smashDuration);
            smasherObject.transform.position = smasherDefaultPosition.transform.position;
            smasherObject.SetActive(false);
            ableToSmash = true;
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

        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        {
            currentTarget = hit.transform.gameObject;

            if (currentTarget.CompareTag(inventoryManager.tagsList[inventoryManager.CurrentIndex]))
            {
                onTarget = true;
                cursorObject.SetActive(true);
                cursorObject.transform.position = hit.point;
            }
            else
            {
                onTarget = false;
                cursorObject.SetActive(false);
                cursorObject.transform.position = new Vector3(0, 0, 0);
            }

        }
        else
        {
            currentTarget = null;
            onTarget = false;
            cursorObject.SetActive(false);
            cursorObject.transform.position = new Vector3(0, 0, 0);
        }

    }

}

