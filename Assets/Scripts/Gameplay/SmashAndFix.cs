using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashAndFix : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private PlayerInteract playerInteract;
    public GameObject smasherObject;
    public GameObject fixerObject;
    public GameObject smasherDefaultPosition;
    public float smashDuration;
    public bool ableToSmash = true;

    public int smashItemIndex;
    public int fixItemIndex;

    private void Start()
    {
        playerInteract = GetComponent<PlayerInteract>();
        inventoryManager = InventoryManager.Instance;
        InputManager.Instance.onInteract.AddListener(Interact);
        InputManager.Instance.onInteractRelease.AddListener(InteractRelease);
        InputManager.Instance.onCancel.AddListener(Cancel);
    }

    public IEnumerator Smash()
    {
        if (ableToSmash)
        {
            ableToSmash = false;
            smasherObject.SetActive(true);
            smasherObject.transform.position = playerInteract.cursorObject.transform.position;
            yield return new WaitForSecondsRealtime(smashDuration);
            smasherObject.transform.position = smasherDefaultPosition.transform.position;
            smasherObject.SetActive(false);
            ableToSmash = true;
        }
    }

    public IEnumerator Fix()
    {
        if (ableToSmash)
        {
            ableToSmash = false;
            fixerObject.SetActive(true);
            fixerObject.transform.position = playerInteract.cursorObject.transform.position;
            yield return new WaitForSecondsRealtime(smashDuration);
            fixerObject.transform.position = smasherDefaultPosition.transform.position;
            fixerObject.SetActive(false);
            ableToSmash = true;
        }
    }

    public void Interact()
    {
        if (inventoryManager.CurrentIndex == smashItemIndex)
        {
            StartCoroutine(Smash());
        }
        else if(inventoryManager.CurrentIndex == fixItemIndex)
        {
            StartCoroutine(Fix());
        }
    }

    public void InteractRelease()
    {
        // if (inventoryManager.CurrentIndex == smashItemIndex)
        // {
        //     StartCoroutine(Smash());
        // }
        // else if(inventoryManager.CurrentIndex == fixItemIndex)
        // {
        //     StartCoroutine(Fix());
        // }


    }

    public void Cancel()
    {
        // if (inventoryManager.CurrentIndex == 8)
        // {
        //     StartCoroutine(Fix());
        // }
    }
}
