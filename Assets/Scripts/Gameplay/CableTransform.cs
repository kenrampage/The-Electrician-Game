using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableTransform : MonoBehaviour, IInteractable
{
    public GameObject startObj;
    public GameObject endObj;
    public GameObject cableObj;
    public GameObject sampleCable;
    private Vector3 initialScale;

    public Cable cable;


    public bool editMode;
    public bool previewMode;

    // Start is called before the first frame update
    void Start()
    {
        cable = GetComponent<Cable>();
        initialScale = cableObj.transform.localScale;
        UpdateCableTransform();

        InputManager.Instance.onCancel.AddListener(HandleCancelInput);
    }

    // Update is called once per frame
    void Update()
    {
        if (previewMode)
        {
            UpdateCableTransform();
        }
        else if (editMode)
        {
            UpdateCableTransform();
            endObj.transform.position = PlayerHoldPosition.position;
        }


    }

    private void UpdateCableTransform()
    {
        float distance = Vector3.Distance(startObj.transform.position, endObj.transform.position); //Get distance between points
        cableObj.transform.localScale = new Vector3(initialScale.x, distance / 2f, initialScale.z); //sets scale based on distance between points
        sampleCable.transform.localScale = new Vector3(initialScale.x, distance / 2f, initialScale.z);

        Vector3 middlePoint = (startObj.transform.position + endObj.transform.position) / 2f; //Gets position direction in the middle between points
        cableObj.transform.position = middlePoint; //Sets cable position to middle point
        sampleCable.transform.position = middlePoint;

        Vector3 rotationDir = (endObj.transform.position - startObj.transform.position); //Gets rotation direction between points
        cableObj.transform.up = rotationDir;
        sampleCable.transform.up = rotationDir;
    }

    public void SetStartPosition(Vector3 pos)
    {
        startObj.transform.position = pos;
    }

    public void SetEndPosition(Vector3 pos)
    {
        endObj.transform.position = pos;
    }

    public void EditModeOn()
    {
        SampleObjectOn();
        
        editMode = true;
    }

    public void EditModeOff()
    {
        editMode = false;
        UpdateCableTransform();
    }

    public void PreviewModeOn(Vector3 pos)
    {
        SampleObjectOn();
        SetEndPosition(pos);
        previewMode = true;
    }

    public void PreviewModeOff()
    {

        previewMode = false;
        
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    public void HandleCancelInput()
    {
        if (previewMode || editMode)
        {
            print("Cancelling Cable Install!");
            PreviewModeOff();
            EditModeOff();
            if (cable.endNode != null)
            {
                cable.ClearEndNode();
            }

            cable.ClearSourceNode();
            DestroyThis();
        }

    }

    private void SampleObjectOn()
    {

        cableObj.SetActive(false);
        sampleCable.SetActive(true);


    }

    private void SampleObjectOff()
    {

        cableObj.SetActive(true);
        sampleCable.SetActive(false);

    }

    public void Install()
    {
        PreviewModeOff();
        EditModeOff();
        SampleObjectOff();
    }

    public void Edit()
    {
        EditModeOn();
        PreviewModeOff();
        cable.sourceNode.RemoveConnectedNode(cable.endNode);
        cable.ClearEndNode();
        SampleObjectOn();
        
    }



    public void Interact()
    {
        if (!InventoryManager.Instance.editingCable)
        {
            print(this.gameObject.name + " Picked Up!");
            Edit();
            InventoryManager.Instance.PickupCable(this.gameObject);
        }

    }

    public void Cancel()
    {

    }
}
