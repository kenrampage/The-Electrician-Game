using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableTransform : MonoBehaviour, IInteractable
{
    public GameObject startObj;
    public GameObject endObj;
    public GameObject cableObj;
    private Vector3 initialScale;

    public bool beingEdited;
    public bool beingPreviewed;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = cableObj.transform.localScale;
        UpdateCableTransform();

        InputManager.Instance.onCancel.AddListener(HandleCancelInput);
    }

    // Update is called once per frame
    void Update()
    {
        if (beingPreviewed)
        {
            UpdateCableTransform();
        }
        else if (beingEdited)
        {
            UpdateCableTransform();
            endObj.transform.position = PlayerHoldPosition.position;
        }


    }

    private void UpdateCableTransform()
    {
        float distance = Vector3.Distance(startObj.transform.position, endObj.transform.position); //Get distance between points
        cableObj.transform.localScale = new Vector3(initialScale.x, distance / 2f, initialScale.z); //sets scale based on distance between points

        Vector3 middlePoint = (startObj.transform.position + endObj.transform.position) / 2f; //Gets position direction in the middle between points
        cableObj.transform.position = middlePoint; //Sets cable position to middle point

        Vector3 rotationDir = (endObj.transform.position - startObj.transform.position); //Gets rotation direction between points
        cableObj.transform.up = rotationDir;
    }

    public void SetStartPosition(Vector3 pos)
    {
        startObj.transform.position = pos;
    }

    public void SetEndPosition(Vector3 pos)
    {
        endObj.transform.position = pos;
    }

    public void StartEditing()
    {
        beingEdited = true;
    }

    public void EndEditing()
    {
        beingEdited = false;
        UpdateCableTransform();
    }

    public void StartPreview(Vector3 pos)
    {
        SetEndPosition(pos);
        beingPreviewed = true;
    }

    public void EndPreview()
    {
        beingPreviewed = false;
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    public void HandleCancelInput()
    {
        if (beingPreviewed || beingEdited)
        {
            print("Cancelling Cable Install!");
            EndPreview();
            EndEditing();
            DestroyThis();
        }

    }

    public void Interact()
    {
        print("Interacted");
        StartEditing();
        InventoryManager.Instance.PickupCable(this.gameObject);
    }

    public void Cancel()
    {
        
    }
}
