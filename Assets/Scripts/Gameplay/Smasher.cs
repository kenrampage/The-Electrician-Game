using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private PlayerInteract playerInteract;
    public GameObject smasherObject;
    public GameObject smasherSpawnPoint;
    public float smasherVelocity;

    private void Start()
    {
        playerInteract = GetComponent<PlayerInteract>();
        inventoryManager = InventoryManager.Instance;
        InputManager.Instance.onInteract.AddListener(Interact);
        InputManager.Instance.onInteractRelease.AddListener(InteractRelease);
    }

    public void Interact()
    {
        if (inventoryManager.CurrentIndex != 8)
        {

        }

    }

    public void InteractRelease()
    {
        if (inventoryManager.CurrentIndex != 8)
        {

        }
        else if (playerInteract.onTarget)
        {
            print("Smash!");
            GameObject spawnedSmasher = Instantiate(smasherObject, smasherSpawnPoint.transform);
            spawnedSmasher.transform.LookAt(playerInteract.cursorObject.transform);
            spawnedSmasher.GetComponent<Rigidbody>().AddForce(spawnedSmasher.transform.forward * smasherVelocity, ForceMode.Impulse);
        }
    }
}
